using BldIt.Api.Shared;
using BldIt.Api.Shared.MassTransit;
using BldIt.Api.Shared.Middlewares;
using BldIt.Api.Shared.MongoDb;
using BldIt.Api.Shared.Services.Auth;
using BldIt.Api.Shared.Services.Uri;
using BldIt.Api.Shared.Settings;
using BldIt.Api.Shared.Swagger;
using BldIt.Jobs.Core.Models;
using BldIt.Jobs.Core.Repos;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddUriService();

var serviceSettings = 
    builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

builder.Services.AddSwaggerWithAuth(serviceSettings.ServiceName, serviceSettings.ServiceVersion);

//Middlewares
builder.Services.AddTransient<ProblemDetailsExceptionHandlingMiddleware>();

//Add BldIt Auth config
builder.Services.AddBldItAuth(builder.Configuration);

builder.Services.AddMongo();
builder.Services.AddScoped<IJobsRepo, JobsRepo>(serviceProvider =>
{
    var database = serviceProvider.GetService<IMongoDatabase>();
    
    if (database is null)
    {
        throw new ArgumentNullException(nameof(database));
    }
    
    const string jobsCollection = BldItApiConstants.Services.Jobs.Collections.Jobs;
    return new JobsRepo(database, jobsCollection);
});
builder.Services.AddMongoRepository<JobsProject, Guid>(nameof(JobsProject));

builder.Services.AddMassTransitWithRabbitMq(builder.Configuration);

//Helper services

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();