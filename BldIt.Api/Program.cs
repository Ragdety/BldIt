using System;
using AutoMapper;
using BldIt.Api.Hubs;
using BldIt.Api.Options;
using BldIt.Api.Profiles;
using BldIt.Api.Repositories;
using BldIt.Api.Services;
using BldIt.Api.Services.Processes;
using BldIt.Api.Services.Storage;
using BldIt.Data;
using BldIt.Models;
using BldIt.Models.DataModels;
using BldIt.Models.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//Required to see controller endpoints in swagger
builder.Services.AddControllers();

//Used for Socket communication between hubs (frontend and backend)
builder.Services.AddSignalR();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BldIt API", Version = "v1" });   
});

//Scoped Services
builder.Services.AddScoped<TemporaryFileStorage>();
builder.Services.AddScoped<LauncherService>();
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(provider =>
{
    var accessor = provider.GetRequiredService<IHttpContextAccessor>();
    var statusCode = accessor.HttpContext?.Response.StatusCode;
    var message = $"Response was executed with status: {statusCode}";
    return new ResponsesService(statusCode!.Value, message);
});

//Database Services
var connectionString = builder.Configuration.GetConnectionString("BldItDevDb");

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
    {
        options.Password.RequiredLength = 8;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<AppIdentityDbContext>();
//End Database Services

//Automapper
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new JobProfile());
});
var mapper = config.CreateMapper();

//Singleton Services
builder.Services.AddSingleton(mapper);
builder.Services.AddSingleton(provider =>
{
    //Gets the absolute uri. Ex: https://localhost
    var accessor = provider.GetRequiredService<IHttpContextAccessor>();
    var request = accessor.HttpContext?.Request;
    var absoluteUri = string.Concat(request?.Scheme, "://", request?.Host.ToUriComponent(), "/");
    //Pass absoluteUri to constructor of UriService"
    return new UriService(absoluteUri);
});

//BldIt Option services:
var settingsSection = builder.Configuration.GetSection(nameof(BldItEnvVariablesSettings));
var settings = settingsSection.Get<BldItEnvVariablesSettings>();
builder.Services.Configure<BldItEnvVariablesSettings>(settingsSection);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.MapControllers();
app.MapHub<BuildStreamHub>("/buildStream");

app.Run();