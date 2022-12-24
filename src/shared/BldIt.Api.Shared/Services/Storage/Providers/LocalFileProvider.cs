using BldIt.Api.Shared.Services.Storage.Clients;

namespace BldIt.Api.Shared.Services.Storage.Providers;

public class LocalFileProvider : IFileProvider
{
    private readonly IStorageClient _client;

    public LocalFileProvider(IStorageClient client)
    {
        _client = client;
    }

    public async Task<string> SaveScriptAsync(Stream fileStream, BldItApiConstants.Files.ScriptTypeExtensions scriptType)
    {
        var scriptName = BldItApiConstants.Files.GenerateScriptFileName(scriptType);
        
        //Returning the local path to the file instead of the service url.
        //We will take care of returning the service url in the controller.
        return await _client.SaveFileAsync(scriptName, fileStream); 
    }

    public async Task<string> SaveScriptLogAsync(Stream fileStream)
    {
        var logName = BldItApiConstants.Files.GenerateScriptLogFileName();
        return await _client.SaveFileAsync(logName, fileStream);
    }
}