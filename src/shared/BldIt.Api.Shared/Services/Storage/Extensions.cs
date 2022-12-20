using BldIt.Api.Shared.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BldIt.Api.Shared.Services.Storage;

public static class Extensions
{
    public static IServiceCollection AddFileServices(this IServiceCollection services, IConfiguration config)
    {
        var isBldItWorkspacePathConfigPresent = 
            services.SingleOrDefault(x => x.ServiceType == typeof(BldItWorkspacePathConfig) &&
                                          x.Lifetime == ServiceLifetime.Singleton) is not null;
        
        if(!isBldItWorkspacePathConfigPresent)
        {
            services.AddBldItWorkspacePathConfig(config);
        }
        
        var settingsSection = config.GetSection(nameof(FileSettings));
        var settings = settingsSection.Get<FileSettings>();
        
        //If no workingDir is provided, use BldIt Temp folder
        if (string.IsNullOrEmpty(settings.WorkingDirectory))
        {
            var bldItPathConfig = services.BuildServiceProvider().GetRequiredService<BldItWorkspacePathConfig>();
            var bldItTempDir = bldItPathConfig.TempPath;

            if (!Directory.Exists(bldItTempDir))
            {
                Directory.CreateDirectory(bldItTempDir);
            }

            settings.WorkingDirectory = bldItTempDir;
        }
        
        services.Configure<FileSettings>(settingsSection);

        services.AddSingleton<TemporaryFileStorage>();
        switch (settings.Provider)
        {
            case BldItApiConstraints.Files.Providers.Local:
                services.AddSingleton<IFileProvider, LocalFileProvider>();
                break;
            case BldItApiConstraints.Files.Providers.S3:
                throw new NotImplementedException();
            default:
                throw new Exception($"Invalid File Provider: {settings.Provider}");
        }
        
        return services;
    }
}