using System.Collections.Generic;
using BldIt.Api;
using BldIt.Api.Hubs;
using BldIt.Api.Services.Executors;
using BldIt.Api.Services.Storage;
using Microsoft.AspNetCore.Builder;
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
builder.Services.AddScoped<ExecutorService>();

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