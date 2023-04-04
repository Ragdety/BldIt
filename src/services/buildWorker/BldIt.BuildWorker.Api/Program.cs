using System.Text.Json.Serialization;
using BldIt.Api.Shared.Hosting;
using BldIt.Api.Shared.Logging.Serilog;
using BldIt.Api.Shared.MassTransit;
using BldIt.Api.Shared.MongoDb;
using BldIt.Api.Shared.Services.Queue;
using BldIt.Api.Shared.Services.Storage;
using BldIt.Api.Shared.Services.Uri;
using BldIt.Api.Shared.Settings;
using BldIt.Api.Shared.Swagger;
using BldIt.Builds.Contracts.Keys;
using BldIt.BuildWorker.Core.Hubs;
using BldIt.BuildWorker.Core.Interfaces;
using BldIt.BuildWorker.Core.Models;
using BldIt.BuildWorker.Core.Services;
using BldIt.Shared.Git;
using BldIt.Shared.Processes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ConfigureAndAddSerilog(builder.Configuration);
builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        var enumConverter = new JsonStringEnumConverter();
        opts.JsonSerializerOptions.Converters.Add(enumConverter);
    });

//Used for Socket communication between hubs (frontend and backend)
builder.Services.AddSignalR();

var serviceSettings = 
    builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

builder.Services.AddSwaggerWithAuth(serviceSettings.ServiceName, serviceSettings.ServiceVersion);

//MongoDB
builder.Services.AddMongo();
builder.Services.AddMongoRepository<WorkerBuildStep, BuildStepKey>(nameof(WorkerBuildStep));
builder.Services.AddMongoRepository<WorkerBuild, Guid>(nameof(WorkerBuild));
builder.Services.AddMongoRepository<WorkerScmConfig, Guid>(nameof(WorkerScmConfig));
builder.Services.AddMongoRepository<WorkerGitHubCredential, Guid>(nameof(WorkerGitHubCredential));

//Mass Transit
builder.Services.AddMassTransitWithRabbitMq(builder.Configuration);

//File Services
builder.Services.AddFileServices(builder.Configuration);

//Other services
builder.Services.AddSingleton<IBuildWorkerManager, BuildWorkerManager>();

var settingsSection = builder.Configuration.GetSection(nameof(BldItWorkerSettings));
var workerSettings = settingsSection.Get<BldItWorkerSettings>();

if (workerSettings is null)
{
    throw new ArgumentNullException(nameof(workerSettings));
}

//This will bind BldItWorkerSettings to IOptionsMonitor
builder.Services.Configure<BldItWorkerSettings>(settingsSection);

builder.Services.AddSingleton<StartBuildRequestQueue>();
// builder.Services.AddSingleton<IBuildWorkerHubConnectionManager, BuildWorkerHubConnectionManager>();
builder.Services.AddSingleton<BuildLogRegistry>();

builder.Services.AddScoped<IBuildWorker, BuildWorker>();

builder.Services.AddBldItQueue<string>();
builder.Services.AddTransient<ProcessService>();
builder.Services.AddUriService();

builder.Services.AddGit();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsDocker())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(b =>
{
    b.WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.MapControllers();

app.MapHub<BuildStreamHub>("/buildStream");

app.Run();