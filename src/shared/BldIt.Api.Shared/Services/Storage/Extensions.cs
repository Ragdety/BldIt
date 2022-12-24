using BldIt.Api.Shared.Config;
using BldIt.Api.Shared.Services.Storage.Clients;
using BldIt.Api.Shared.Services.Storage.Providers;
using BldIt.Api.Shared.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BldIt.Api.Shared.Services.Storage;

public static class Extensions
{
    public static IServiceCollection AddFileServices(this IServiceCollection services, IConfiguration config)
    {
        var settingsSection = config.GetSection(nameof(FileSettings));
        var settings = settingsSection.Get<FileSettings>();

        if (settings is null)
        {
            throw new ArgumentNullException(nameof(settings));
        }

        //This will bind FileSettings to IOptionsMonitor
        services.Configure<FileSettings>(settingsSection);

        //This is to manage the workspace folders for BldIt
        //(this depends on the FileSettings to determine if it is a local storage or S3 bucket)
        services.AddSingleton<BldItWorkspaceConfig>();

        //Add Temporary File Storage
        services.AddSingleton<TemporaryFileStorage>();

        switch (settings.Provider)
        {
            case BldItApiConstants.Files.Providers.Local:
                services.AddSingleton<IStorageClient, LocalStorageClient>();
                services.AddSingleton<IFileProvider, LocalFileProvider>();
                break;
            case BldItApiConstants.Files.Providers.S3:
                //TODO: Configure S3 settings here with services.Configure<S3Settings>(s3SettingsSection);
                services.AddSingleton<IStorageClient, S3StorageClient>();
                services.AddSingleton<IFileProvider, S3FileProvider>();
                break;
            default:
                throw new Exception($"Invalid File Provider: {settings.Provider}");
        }
        
        return services;
    }
}