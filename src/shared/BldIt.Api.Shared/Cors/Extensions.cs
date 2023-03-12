using BldIt.Api.Shared.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BldIt.Api.Shared.Cors;

public static class Extensions
{
    public static IServiceCollection AddBldItCors(this IServiceCollection services, IConfiguration config)
    {
        var settingsSection = config.GetSection(nameof(CorsHostSettings));
        var settings = settingsSection.Get<CorsHostSettings>();

        if (settings is null)
        {
            throw new ArgumentNullException(nameof(settings));
        }

        //This will bind CorsHostSettings to IOptionsMonitor
        services.Configure<CorsHostSettings>(settingsSection);

        services.AddCors(options =>
        {
            options.AddPolicy(BldItApiConstants.Policies.BldItCors,
                b =>
                {
                    b.WithOrigins(settings.WebClient, settings.SecureWebClient)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
        });
        return services;
    }
}