using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BldIt.Api.Shared.Swagger;

public static class Extensions
{
    public static IServiceCollection AddSwaggerWithAuth(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
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
        return services;
    }
}