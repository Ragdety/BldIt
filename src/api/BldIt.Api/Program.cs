using BldIt.Api.Shared.Cors;
using BldIt.Api.Shared.Hosting;
using BldIt.Api.Shared.Logging.Serilog;
using BldIt.Api.Shared.Services.Auth;
using BldIt.Api.Shared.Settings;
using BldIt.Api.Shared.Swagger;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", optional:true, reloadOnChange:true)
    .AddEnvironmentVariables();
builder.Logging.ConfigureAndAddSerilog(builder.Configuration);

var serviceSettings = 
    builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

builder.Services.AddSwaggerWithAuth(serviceSettings.ServiceName, serviceSettings.ServiceVersion);
builder.Services.AddSwaggerForOcelot(builder.Configuration);
builder.Services.AddBldItAuth(builder.Configuration);

//builder.Services.AddBldItCors(builder.Configuration);
builder.Services.AddCors();
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsDocker())
{
    app.UseSwagger();
    app.UseSwaggerForOcelotUI();
}

// app.UseCors(BldItApiConstants.Policies.BldItCors);
app.UseBldItCors(builder.Configuration);

app.UseAuthentication();
app.UseAuthorization();

app.UseOcelot().Wait();


app.Run();