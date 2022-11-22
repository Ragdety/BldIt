using BldIt.Api.Shared;
using BldIt.Api.Shared.Middlewares;
using BldIt.Api.Shared.Services.Auth;
using BldIt.Api.Shared.Services.Uri;
using BldIt.Api.Shared.Settings;
using BldIt.Api.Shared.Swagger;
using BldIt.Identity.Core.Models;
using BldIt.Identity.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddUriService();

var serviceSettings = 
    builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithBldItService(serviceSettings.ServiceName, serviceSettings.ServiceVersion);

//Middlewares
builder.Services.AddTransient<ProblemDetailsExceptionHandlingMiddleware>();

builder.Services.AddIdentityRepositories();

var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
builder.Services.AddIdentity<User, Role>(options =>
    {
        options.Password.RequiredLength = 5;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
    })
    .AddRoles<Role>()
    .AddMongoDbStores<User, Role, Guid>(mongoDbSettings.ConnectionString, mongoDbSettings.Name);

builder.Services.AddBldItAuth(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseMiddleware<ProblemDetailsExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();