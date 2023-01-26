using BldIt.Api.Shared.Services.Storage.Clients;

namespace BldIt.Api.Shared.Services.Storage.Providers;

public class LocalFileProvider : IFileProvider
{
    private readonly IStorageClient _client;
    private readonly TemporaryFileStorage _tempFileStorage;

    public LocalFileProvider(IStorageClient client, TemporaryFileStorage tempFileStorage)
    {
        _client = client;
        _tempFileStorage = tempFileStorage;
    }

    public async Task<string> SaveScriptAsync(Stream fileStream, BldItApiConstants.Files.ScriptTypeExtensions scriptType)
    {
        var scriptName = BldItApiConstants.Files.GenerateScriptFileName(scriptType);
        
        //Returning the local path to the file instead of the service url.
        //We will take care of returning the service url in the controller.
        return await _client.SaveFileAsync(scriptName, fileStream); 
    }

    /// <summary>
    /// Saves the build log from the temp folder to the build folder
    /// </summary>
    /// <param name="buildFolderPath">The build folder path. Ex: "/projects/Proj1/jobs/TestJob/builds/3"</param>
    /// <param name="tempLogFilePath">Location of the temporary log file</param>
    /// <remarks>
    /// The buildFolderPath will be given by BldItWorkspaceConfig BuildPath() function
    /// </remarks>
    public void SaveBuildLogFromTemp(string buildFolderPath, string tempLogFilePath)
    { 
        var buildLogName = BldItApiConstants.Files.GenerateScriptLogFileName();
        var logPath = Path.Combine(buildFolderPath, buildLogName);
        _client.CopyFile(tempLogFilePath, logPath);
        
        //Delete temp log file
        var logName = Path.GetFileName(tempLogFilePath);
        _tempFileStorage.DeleteTemporaryFile(logName);
    }
}