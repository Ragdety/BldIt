using BldIt.Api.Shared.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BldIt.Api.Shared.Services.Storage;

public static class Extensions
{
    public static IServiceCollection AddFileServices(this IServiceCollection services, IConfiguration config)
    {
        var settingsSection = config.GetSection(nameof(FileSettings));
        var settings = settingsSection.Get<FileSettings>();
        
        //If no workingDir is provided, use BldIt Temp folder
        if (string.IsNullOrEmpty(settings.WorkingDirectory))
        {
            var bldItPathConfig = services.BuildServiceProvider().GetRequiredService<BldItWorkspacePathConfig>();
            var logger = services.BuildServiceProvider().GetRequiredService<ILogger>();

            if (bldItPathConfig == null)
            {
                logger.LogError("BldItWorkspacePathConfig is null. Must call AddBldItWorkspacePathConfig() before AddFileServices()");
                throw new ArgumentNullException(nameof(bldItPathConfig));
            }
            
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