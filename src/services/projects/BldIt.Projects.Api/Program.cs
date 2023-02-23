using System.Text.Json.Serialization;
using BldIt.Api.Shared;
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
using BldIt.Projects.Core.Repos;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ConfigureAndAddSerilog(builder.Configuration);

builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        var enumConverter = new JsonStringEnumConverter();
        opts.JsonSerializerOptions.Converters.Add(enumConverter);
    });
builder.Services.AddUriService();

//Configure bldit workspace paths and file services
builder.Services.AddFileServices(builder.Configuration);

//Swagger Settings
var serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

if (serviceSettings is null) throw new ArgumentNullException(nameof(serviceSettings));

builder.Services.AddSwaggerWithAuth(serviceSettings.ServiceName, serviceSettings.ServiceVersion);
//End Swagger Settings

//Middlewares
builder.Services.AddTransient<ProblemDetailsExceptionHandlingMiddleware>();

//Add BldIt Auth config
builder.Services.AddBldItAuth(builder.Configuration);

//Add MongoDb settings & repos
builder.Services.AddMongo();
builder.Services.AddScoped<IProjectRepo, ProjectRepo>(serviceProvider =>
{
    var database = serviceProvider.GetService<IMongoDatabase>();
    
    if (database is null)
    {
        throw new ArgumentNullException(nameof(database));
    }
    
    const string projectsCollection = BldItApiConstants.Services.Projects.Collections.Projects;
    return new ProjectRepo(database, projectsCollection);
});

builder.Services.AddMassTransitWithRabbitMq(builder.Configuration);

//Helper services:


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsDocker())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseMiddleware<ProblemDetailsExceptionHandlingMiddleware>();

app.UseCors(b =>
{
    b.WithOrigins("http://localhost:3000", "https://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();