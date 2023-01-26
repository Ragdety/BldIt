using BldIt.Api.Shared.Config;

namespace BldIt.Api.Shared.Services.Storage.Clients;

public class LocalStorageClient : IStorageClient
{
    private readonly BldItWorkspaceConfig _config;
    
    public LocalStorageClient(BldItWorkspaceConfig config)
    {
        _config = config;
    }
    
    public async Task<string> SaveFileAsync(string filePath, Stream fileStream)
    {
        await using var stream = File.Create(filePath);
        await fileStream.CopyToAsync(stream);
        return filePath;
    }

    public void CopyFile(string sourcePath, string destinationPath) => 
        File.Copy(sourcePath, destinationPath);
    
}