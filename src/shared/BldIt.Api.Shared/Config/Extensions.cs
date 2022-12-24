using BldIt.Api.Shared.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BldIt.Api.Shared.Config;

[Obsolete("Inject FileSettings and add BldItWorkspaceConfig itself to the services instead")]
public static class Extensions
{
    [Obsolete("Inject FileSettings and add BldItWorkspaceConfig itself to the services instead")]
    public static IServiceCollection AddBldItWorkspacePathConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var settingsSection = configuration.GetSection(nameof(BldItWorkspaceSettings));

        if (settingsSection is null)
        {
            throw new ArgumentNullException(nameof(ServiceSettings));
        }
        
        services.Configure<BldItWorkspaceSettings>(settingsSection);
        services.AddSingleton<BldItWorkspaceConfig>();
        return services;
    }
}