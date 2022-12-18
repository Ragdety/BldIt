using BldIt.Api.Shared;
using BldIt.Api.Shared.Hosting;
using BldIt.Api.Shared.Logging.Serilog;
using BldIt.Api.Shared.MassTransit;
using BldIt.Api.Shared.Middlewares;
using BldIt.Api.Shared.MongoDb;
using BldIt.Api.Shared.Services.Auth;
using BldIt.Api.Shared.Services.Uri;
using BldIt.Api.Shared.Settings;
using BldIt.Api.Shared.Swagger;
using BldIt.Jobs.Core.Models;
using BldIt.Jobs.Core.Repos;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ConfigureAndAddSerilog(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddUriService();

var serviceSettings = 
    builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

builder.Services.AddSwaggerWithAuth(serviceSettings.ServiceName, serviceSettings.ServiceVersion);

//Add BldIt Auth config
builder.Services.AddBldItAuth(builder.Configuration);

//MongoDb
builder.Services.AddMongo();
builder.Services.AddMongoRepository<IJobsRepo, JobsRepo, Job, Guid>(BldItApiConstants.Services.Jobs.Collections.Jobs);
builder.Services.AddMongoRepository<JobsProject, Guid>(nameof(JobsProject));
builder.Services.AddMongoRepository<JobConfig, Guid>(nameof(JobConfig));

//MassTransit
builder.Services.AddMassTransitWithRabbitMq(builder.Configuration);

//Middlewares
builder.Services.AddTransient<ProblemDetailsExceptionHandlingMiddleware>();

//Helper services

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