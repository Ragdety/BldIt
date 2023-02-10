using System.Text.Json.Serialization;
using BldIt.Api.Shared.Hosting;
using BldIt.Api.Shared.Logging.Serilog;
using BldIt.Api.Shared.MassTransit;
using BldIt.Api.Shared.MongoDb;
using BldIt.Api.Shared.Services.Storage;
using BldIt.Api.Shared.Services.Uri;
using BldIt.Api.Shared.Settings;
using BldIt.Api.Shared.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ConfigureAndAddSerilog(builder.Configuration);
builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        var enumConverter = new JsonStringEnumConverter();
        opts.JsonSerializerOptions.Converters.Add(enumConverter);
    });

var serviceSettings = 
    builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

builder.Services.AddSwaggerWithAuth(serviceSettings.ServiceName, serviceSettings.ServiceVersion);

//MongoDB
builder.Services.AddMongo();
//builder.Services.AddMongoRepository<WorkerBuildStep, BuildStepKey>(nameof(WorkerBuildStep));

//Mass Transit
builder.Services.AddMassTransitWithRabbitMq(builder.Configuration);

//File Services
//This allows the FileService class to be monitored by IOptionsMonitor
builder.Services.AddFileServices(builder.Configuration);

//Other services
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