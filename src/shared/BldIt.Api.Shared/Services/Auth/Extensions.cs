using System.Text;
using BldIt.Api.Shared.Services.Auth.Utilities;
using BldIt.Api.Shared.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BldIt.Api.Shared.Services.Auth;

public static class Extensions
{
    public static IServiceCollection AddBldItAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var settingsSection = configuration.GetSection(nameof(JwtSettings));
        var jwtSettings = settingsSection.Get<JwtSettings>();

        if (jwtSettings == null)
        {
            throw new ArgumentNullException(nameof(jwtSettings));
        }
        
        services.Configure<JwtSettings>(settingsSection);
        
        services.AddSingleton(jwtSettings);
        
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false,
            ValidateLifetime = true
        };
        
        services.AddSingleton(tokenValidationParameters);
        
        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie(c =>
            {
                c.Cookie.Name = JwtTokenUtilities.CookieName;
            })
            .AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = tokenValidationParameters;
                x.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Cookies[JwtTokenUtilities.CookieName];
                        context.Token = accessToken;
                        return Task.CompletedTask;
                    }
                };
            });
        return services;
    }
}