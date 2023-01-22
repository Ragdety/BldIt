using BldIt.Api.Shared.Hosting;
using BldIt.Api.Shared.Logging.Serilog;
using BldIt.Api.Shared.MassTransit;
using BldIt.Api.Shared.MongoDb;
using BldIt.Api.Shared.Services.Storage;
using BldIt.Api.Shared.Services.Uri;
using BldIt.Api.Shared.Settings;
using BldIt.Api.Shared.Swagger;
using BldIt.Builds.Contracts.Keys;
using BldIt.BuildScheduler.Api.BackgroundServices;
using BldIt.BuildScheduler.Core.Interfaces;
using BldIt.BuildScheduler.Core.Models;
using BldIt.BuildScheduler.Core.Services;
using BldIt.Shared.Processes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ConfigureAndAddSerilog(builder.Configuration);
builder.Services.AddControllers();

//Used for Socket communication between hubs (frontend and backend)
builder.Services.AddSignalR();
builder.Services.AddHostedService<BuildScheduler>();

var serviceSettings = 
    builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

builder.Services.AddSwaggerWithAuth(serviceSettings.ServiceName, serviceSettings.ServiceVersion);

//MongoDB
builder.Services.AddMongo();
builder.Services.AddMongoRepository<SchedulerBuildStep, BuildStepKey>(nameof(SchedulerBuildStep));

//Mass Transit
builder.Services.AddMassTransitWithRabbitMq(builder.Configuration);

//File Services
builder.Services.AddFileServices(builder.Configuration);

//Other services
builder.Services.AddSingleton<IBuildQueue, BuildQueue>();
builder.Services.AddTransient<ProcessService>();
builder.Services.AddUriService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsDocker())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();