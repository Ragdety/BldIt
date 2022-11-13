using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            var bldItHome = 
                Environment.GetEnvironmentVariable(BldItApiConstants.BldItEnvironmentNames.BLDIT_HOME);
            
            if (bldItHome == null)
            {
                throw new ArgumentNullException(nameof(bldItHome));
            }
            
            var bldItTempDir = Path.Combine(bldItHome, BldItApiConstraints.Files.BldItTempFolderName);

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