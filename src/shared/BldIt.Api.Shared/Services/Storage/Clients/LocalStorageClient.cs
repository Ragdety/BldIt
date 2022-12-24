using BldIt.Api.Shared.Config;

namespace BldIt.Api.Shared.Services.Storage.Clients;

public class LocalStorageClient : IStorageClient
{
    private readonly BldItWorkspaceConfig _config;
    
    public LocalStorageClient(BldItWorkspaceConfig config)
    {
        _config = config;
    }
    
    public async Task<string> SaveFileAsync(string fileName, Stream fileStream, string? mime = null)
    {
        //Save it to files path, to then move the returned save path file into its actual storage location,
        //Such as the job folder, or the project folder or the builds folder
        var savePath = Path.Combine(_config.FilesPath(), fileName);
        await using var stream = File.Create(savePath);
        await fileStream.CopyToAsync(stream);
        return savePath;
    }
}