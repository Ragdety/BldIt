using BldIt.Api.Shared.Services.Storage.Clients;

namespace BldIt.Api.Shared.Services.Storage.Providers;

public class S3FileProvider : IFileProvider
{
    private readonly IStorageClient _client;

    public S3FileProvider(IStorageClient client)
    {
        _client = client;
    }
    
    public Task<string> SaveScriptAsync(Stream fileStream, BldItApiConstants.Files.ScriptTypeExtensions scriptType)
    {
        throw new NotImplementedException();
    }

    public void SaveBuildLogFromTemp(string buildFolderPath, string tempLogFileName)
    {
        throw new NotImplementedException();
    }
}