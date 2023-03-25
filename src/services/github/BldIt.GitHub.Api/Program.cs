using System.Security.Claims;
using AspNet.Security.OAuth.GitHub;
using BldIt.Api.Shared;
using BldIt.Api.Shared.Cors;
using BldIt.Api.Shared.GitHub;
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
using BldIt.GitHub.Core.Interfaces;
using BldIt.GitHub.Core.Models;
using BldIt.GitHub.Core.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ConfigureAndAddSerilog(builder.Configuration);
builder.Services.AddControllers();

var serviceSettings = 
    builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

builder.Services.AddSwaggerWithAuth(serviceSettings.ServiceName, serviceSettings.ServiceVersion);

builder.Services.AddBldItAuth(builder.Configuration);
//     .AddAuthentication(o =>
//     {
//         o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//         o.DefaultChallengeScheme = GitHubAuthenticationDefaults.AuthenticationScheme;
//     })
//     .AddCookie(o =>
//     {
//         o.Cookie.Name = ".AspNetCore.MyCookie";
//         o.LoginPath = new PathString(Routes.GitHub.Auth.Login);
//     })
//     .AddGitHub(BldItApiConstants.AuthenticationSchemes.GitHub, o =>
//     {
//         o.CorrelationCookie.Name = ".AspNetCore.Correlation.MyCookie";
//         o.CorrelationCookie.SameSite = SameSiteMode.None;
//         o.CorrelationCookie.SecurePolicy = CookieSecurePolicy.Always;
//         
//         o.Scope.Add("read:user");
//         o.SaveTokens = true;
//         
//         o.Events.OnCreatingTicket = ctx =>
//         {
//             if (ctx.AccessToken is null) return Task.CompletedTask;
//             
//             var logger = ctx.HttpContext.RequestServices.GetService<ILogger>();
//                 
//             if (logger is null) 
//                 throw new ArgumentNullException(nameof(logger));
//                 
//             //Add the access token to the claims
//             //ctx.Identity?.AddClaim(new Claim("github:access_token", ctx.AccessToken));
//             logger.LogInformation("ACCESS TOKEN from TICKET: {token}", ctx.AccessToken);
//
//             return Task.CompletedTask;
//         };
//     });

//MongoDB
builder.Services.AddMongo();
builder.Services.AddMongoRepository<GitHubConfig, Guid>(nameof(GitHubConfig));
builder.Services.AddMongoRepository<GitHubCredential, Guid>(nameof(GitHubCredential));
builder.Services.AddMongoRepository<GitHubUser, string>(nameof(GitHubUser));

//Middlewares
builder.Services.AddTransient<ProblemDetailsExceptionHandlingMiddleware>();

//Mass Transit
builder.Services.AddMassTransitWithRabbitMq(builder.Configuration);

//File Services
builder.Services.AddFileServices(builder.Configuration);
builder.Services.AddCors();

builder.Services.AddHttpClient<IGitHubService, GitHubService>(client =>
{
    client.BaseAddress = new Uri("https://api.github.com");
});

builder.Services.AddUriService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsDocker())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ProblemDetailsExceptionHandlingMiddleware>();
app.UseBldItCors(builder.Configuration);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();