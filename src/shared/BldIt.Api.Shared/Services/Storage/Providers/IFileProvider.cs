namespace BldIt.Api.Shared.Services.Storage.Providers;

public interface IFileProvider
{
    Task<string> SaveScriptAsync(Stream fileStream, BldItApiConstants.Files.ScriptTypeExtensions scriptType);
    void SaveBuildLogFromTemp(string buildFolderPath, string tempLogFileName);
}