using BldIt.Api.Shared;
using BldIt.Api.Shared.Config;
using BldIt.Api.Shared.Hosting;
using BldIt.Api.Shared.Logging.Serilog;
using BldIt.Api.Shared.MassTransit;
using BldIt.Api.Shared.Middlewares;
using BldIt.Api.Shared.MongoDb;
using BldIt.Api.Shared.Services.Auth;
using BldIt.Api.Shared.Services.Storage;
using BldIt.Api.Shared.Services.Uri;
using BldIt.Api.Shared.Settings;
using BldIt.Api.Shared.Swagger;
using BldIt.Builds.Core.Keys;
using BldIt.Builds.Core.Models;
using BldIt.Builds.Core.Repos;
using BldIt.Shared.Processes;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ConfigureAndAddSerilog(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddUriService();

//Used for Socket communication between hubs (frontend and backend)
builder.Services.AddSignalR();

var serviceSettings = 
    builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

builder.Services.AddSwaggerWithAuth(serviceSettings.ServiceName, serviceSettings.ServiceVersion);

//Add BldIt Auth config
builder.Services.AddBldItAuth(builder.Configuration);

//MongoDb
builder.Services.AddMongo();
builder.Services.AddMongoRepository<IBuildsRepo, BuildsRepo, Build, Guid>
    (BldItApiConstants.Services.Builds.Collections.Builds);
builder.Services.AddMongoRepository<BuildsJob, Guid>(nameof(BuildsJob));
builder.Services.AddMongoRepository<IBuildConfigRepo, BuildConfigRepo, BuildConfig, Guid>
    (BldItApiConstants.Services.Builds.Collections.BuildConfigs);
builder.Services.AddMongoRepository<BuildStep, BuildStepKey>(BldItApiConstants.Services.Builds.Collections.BuildSteps);

//MassTransit
builder.Services.AddMassTransitWithRabbitMq(builder.Configuration);

//File Services
builder.Services.AddBldItWorkspacePathConfig(builder.Configuration);
//builder.Services.AddFileServices(builder.Configuration);

//Middlewares
builder.Services.AddTransient<ProblemDetailsExceptionHandlingMiddleware>();

//Other Services
builder.Services.AddTransient<ProcessService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsDocker())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ProblemDetailsExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();