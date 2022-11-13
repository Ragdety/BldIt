using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BldIt.Api.Shared.Services.Storage;

public static class Extensions
{
    public static IServiceCollection AddFileServices(this IServiceCollection services, IConfiguration config)
    {
        var settingsSection = config.GetSection(nameof(FileSettings));
        var settings = settingsSection.Get<FileSettings>();
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