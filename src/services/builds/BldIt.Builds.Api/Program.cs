using System.Text.Json.Serialization;
using BldIt.Api.Shared;
using BldIt.Api.Shared.Cors;
using BldIt.Api.Shared.Hosting;
using BldIt.Api.Shared.Logging.Serilog;
using BldIt.Api.Shared.MassTransit;
using BldIt.Api.Shared.Middlewares;
using BldIt.Api.Shared.MongoDb;
using BldIt.Api.Shared.Services.Auth;
using BldIt.Api.Shared.Services.Uri;
using BldIt.Api.Shared.Settings;
using BldIt.Api.Shared.Swagger;
using BldIt.Builds.Core.Models;
using BldIt.Builds.Core.Repos;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ConfigureAndAddSerilog(builder.Configuration);

builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        var enumConverter = new JsonStringEnumConverter();
        opts.JsonSerializerOptions.Converters.Add(enumConverter);
    });
builder.Services.AddUriService();

//Used for Socket communication between hubs (frontend and backend)
builder.Services.AddSignalR();

var serviceSettings = 
    builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

builder.Services.AddSwaggerWithAuth(serviceSettings.ServiceName, serviceSettings.ServiceVersion);

builder.Services.AddCors();
//Add BldIt Auth config
builder.Services.AddBldItAuth(builder.Configuration);

//MongoDb
builder.Services.AddMongo();
builder.Services.AddMongoRepository<IBuildsRepo, BuildsRepo, Build, Guid>
    (BldItApiConstants.Services.Builds.Collections.Builds);
builder.Services.AddMongoRepository<BuildsJob, Guid>(nameof(BuildsJob));
builder.Services.AddMongoRepository<BuildsJobConfig, Guid>(nameof(BuildsJobConfig));
builder.Services.AddMongoRepository<IBuildConfigRepo, BuildConfigRepo, BuildConfig, Guid>
    (BldItApiConstants.Services.Builds.Collections.BuildConfigs);
builder.Services.AddMongoRepository<BuildStep, Guid>(BldItApiConstants.Services.Builds.Collections.BuildSteps);

//MassTransit
builder.Services.AddMassTransitWithRabbitMq(builder.Configuration);

//Middlewares
builder.Services.AddTransient<ProblemDetailsExceptionHandlingMiddleware>();

//Other Services

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsDocker())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ProblemDetailsExceptionHandlingMiddleware>();
app.UseBldItCors(builder.Configuration);

app.UseAuthorization();


app.MapControllers();

app.Run();