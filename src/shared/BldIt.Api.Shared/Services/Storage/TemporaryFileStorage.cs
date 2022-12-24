using BldIt.Api.Shared.Config;
using Microsoft.AspNetCore.Http;

namespace BldIt.Api.Shared.Services.Storage;

public class TemporaryFileStorage
{
    private readonly BldItWorkspaceConfig _config;

    public TemporaryFileStorage(BldItWorkspaceConfig config)
    {
        _config = config;
    }
    
    /// <summary>
    /// Saves a temporary file in the temp directory from BldItWorkspaceConfig based on the FormFile
    /// </summary>
    /// <param name="file">The file coming from the form</param>
    /// <returns>The save path of the created file</returns>
    public async Task<string> SaveTemporaryFormFileAsync(IFormFile file)
    {
        var fileName = GetBldItTempFileName(Path.GetExtension(file.FileName));
        var savePath = GetSavePath(fileName);

        if (_config.IsLocalProvider)
        {
            await using var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write);
            await file.CopyToAsync(fileStream);
        }
        else if (_config.IsS3Provider)
        {
            throw new NotImplementedException("S3 not implemented yet");
        }

        return savePath;
    }

    /// <summary>
    /// Creates a temporary file in the temp directory from BldItWorkspaceConfig
    /// with the specified content
    /// </summary>
    /// <param name="fileStream">Content stream will be copied to the temp file</param>
    /// <param name="extension">Script extension based on type of script</param>
    /// <returns>The save path of the created file</returns>
    public async Task<string> CreateTemporaryScriptFileAsync(Stream fileStream, string extension)
    {
        var fName = GetBldItTempFileName(extension);
        var savePath = GetSavePath(fName);
        return await CreateTemporaryFileAsync(fileStream, savePath);
    }
    
    /// <summary>
    /// Creates a temporary file in the temp directory from BldItWorkspaceConfig
    /// with the specified content
    /// </summary>
    /// <param name="fileContent">Content string will be copied to the temp file</param>
    /// <param name="extension">Script extension based on type of script</param>
    /// <returns>The save path of the created file</returns>
    public async Task<string> CreateTemporaryScriptFileAsync(string fileContent, string extension)
    {
        var fName = GetBldItTempFileName(extension);
        var savePath = GetSavePath(fName);
        return await CreateTemporaryFileAsync(fileContent, savePath);
    }

    /// <summary>
    /// Creates a temporary log file in the temp directory from BldItWorkspaceConfig
    /// with the specified log stream
    /// </summary>
    /// <param name="fileStream">Log stream that will be copied to the temp file</param>
    /// <returns>The save path of the created log</returns>
    public async Task<string> CreateTemporaryLogFileAsync(Stream fileStream)
    {
        var fName = GetBldItTempFileName(BldItApiConstants.Files.BldItLogExtension);
        var savePath = GetSavePath(fName);
        return await CreateTemporaryFileAsync(fileStream, savePath);
    }
    
    
    /// <summary>
    /// Creates a temporary log file in the temp directory from BldItWorkspaceConfig
    /// with the specified log stream
    /// </summary>
    /// <param name="fileContent">Log content string that will be copied to the temp file</param>
    /// <returns>The save path of the created log</returns>
    public async Task<string> CreateTemporaryLogFileAsync(string fileContent)
    {
        var fName = GetBldItTempFileName(BldItApiConstants.Files.BldItLogExtension);
        var savePath = GetSavePath(fName);
        return await CreateTemporaryFileAsync(fileContent, savePath);
    }

    /// <summary>
    /// Checks if the temp file exists inside the working directory from FileSettings
    /// </summary>
    /// <param name="fileName">Name of the file inside the working directory</param>
    /// <returns>True if the file exists, otherwise false</returns>
    public bool TemporaryFileExists(string fileName)
    {
        var path = GetSavePath(fileName);

        if (_config.IsLocalProvider)
        {
            return File.Exists(path);
        }
        
        if (_config.IsS3Provider)
        {
            throw new NotImplementedException("S3 provider not implemented yet");
        }
        
        throw new ArgumentException("Invalid provider, please check your FileSettings configuration");
    }

    /// <summary>
    /// Deletes the temporary file in the working directory from FileSettings
    /// </summary>
    /// <param name="fileName">File name to delete</param>
    public void DeleteTemporaryFile(string fileName)
    {
        var path = GetSavePath(fileName);

        if (_config.IsLocalProvider)
        {
            if (File.Exists(path)) File.Delete(path);
        }
        else if (_config.IsS3Provider)
        {
            throw new NotImplementedException("S3 provider not implemented yet");
        }
    }

    /// <summary>
    /// Gets the full path of the file inside the working directory from FileSettings
    /// </summary>
    /// <param name="fileName">File name that needs the full path</param>
    /// <returns>Full path of the fileName</returns>
    public string GetSavePath(string fileName)
    {
        return Path.Combine(_config.TempPath(), fileName);
    }

    /// <summary>
    /// Gets the bldit temp file name format
    /// </summary>
    /// <param name="extension">Optional file extension. If not provided .temp will be used</param>
    /// <returns>New name of file in bldit temp file format</returns>
    private static string GetBldItTempFileName(string? extension)
    {
        var base64Guid = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        
        return string.Concat(
            BldItApiConstants.Files.BldItTempPrefix,
            DateTime.Now.Ticks,
            base64Guid,
            extension ?? BldItApiConstants.Files.BldItTempExtension
        );
    }
    
    private async Task<string> CreateTemporaryFileAsync(Stream fileStream, string savePath)
    {
        if (_config.IsLocalProvider)
        {
            await using var stream = File.Create(savePath);
            await fileStream.CopyToAsync(stream);
        }
        else if (_config.IsS3Provider)
        {
            throw new NotImplementedException("S3 not implemented yet");
        }

        return savePath;
    }

    private async Task<string> CreateTemporaryFileAsync(string fileContent, string savePath)
    {
        if (_config.IsLocalProvider)
        {
            await File.WriteAllTextAsync(savePath, fileContent);
        }
        else if (_config.IsS3Provider)
        {
            throw new NotImplementedException("S3 not implemented yet");
        }

        return savePath;
    }
}