using BldIt.Api.Shared;
using BldIt.Api.Shared.Config;
using BldIt.Api.Shared.Interfaces;
using BldIt.Api.Shared.MongoDb;
using BldIt.Api.Shared.Services;
using BldIt.Api.Shared.Services.Auth;
using BldIt.Api.Shared.Settings;
using BldIt.Api.Shared.Swagger;
using BldIt.Projects.Core.Models;
using BldIt.Projects.Core.Repos;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

//Configure bldit workspace paths
builder.Services.AddBldItWorkspacePathConfig(builder.Configuration);

//Swagger Settings
var serviceSettings = 
    builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
builder.Services.AddSwaggerWithAuth(serviceSettings.ServiceName, serviceSettings.ServiceVersion);
//End Swagger Settings

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

//Helper services:

//UriService: Used to generate links to resources
builder.Services.AddSingleton(provider =>
{
    //Gets the absolute uri. Ex: https://localhost
    var accessor = provider.GetRequiredService<IHttpContextAccessor>();
    var request = accessor.HttpContext?.Request;
    var absoluteUri = string.Concat(request?.Scheme, "://", request?.Host.ToUriComponent(), "/");
    //Pass absoluteUri to constructor of UriService"
    return new UriService(absoluteUri);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();