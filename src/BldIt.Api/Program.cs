using System.Text;
using AutoMapper;
using BldIt.Api.Filters;
using BldIt.Api.Hubs;
using BldIt.Api.Middlewares;
using BldIt.Api.Options;
using BldIt.Api.Profiles;
using BldIt.Api.Services;
using BldIt.Api.Services.Processes;
using BldIt.Api.Services.Storage;
using BldIt.Api.Validators;
using BldIt.Data;
using BldIt.Data.Repositories;
using BldIt.Data.Settings;
using BldIt.Models.DataModels;
using BldIt.Models.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BldIt.API", Version = "v1" });
    
    //To add jwt auth
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "JWT Authorization header using the bearer scheme",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    };
    
    var security = new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme  
            {  
                Reference = new OpenApiReference  
                {  
                    Type = ReferenceType.SecurityScheme,  
                    Id = "Bearer"  
                }  
            },
            Array.Empty<string>()
        } 
    };
    c.AddSecurityDefinition("Bearer", securityScheme);
    c.AddSecurityRequirement(security);
    c.ResolveConflictingActions (apiDescriptions => apiDescriptions.First());
});

//Scoped Services
builder.Services.AddScoped<TemporaryFileStorage>();
builder.Services.AddScoped<LauncherService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IIdentityRepository, IdentityRepository>();

builder.Services.AddHttpContextAccessor();

//Transient Services
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

//Database Services
var connectionString = builder.Configuration.GetConnectionString("BldItDb");
builder.Services.AddDbContext<AppIdentityDbContext>(config =>
{
    config.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
    {
        options.Password.RequiredLength = 5;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
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

builder.Services
    .AddControllers(options =>
    {
        options.EnableEndpointRouting = false;
        options.Filters.Add(typeof(ValidationFilter));
    })
    .AddFluentValidation(c => 
        c.RegisterValidatorsFromAssemblyContaining<JobCreationFormValidator>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

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
builder.Services.Configure<BldItEnvVariablesSettings>(settingsSection);

//Authentication services:
var jwtSettings = new JwtSettings();
builder.Configuration.Bind(nameof(jwtSettings), jwtSettings);
builder.Services.AddSingleton(jwtSettings);
builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false,
            ValidateLifetime = true
        };
    });
//End Auth Services

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();

var corsHostsOptions = new CorsHostsOptions();
builder.Configuration.Bind(nameof(corsHostsOptions), corsHostsOptions);

app.UseCors(corsPolicyBuilder => corsPolicyBuilder
    .WithOrigins(
        corsHostsOptions.LocalWebClient,
        corsHostsOptions.LocalSecureWebClient
    )
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<BuildStreamHub>("/buildStream");
});

app.Run();