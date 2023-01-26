namespace BldIt.Api.Shared.Services.Storage.Clients;

public interface IStorageClient
{
    /// <summary>
    /// Store and save the file with the given path
    /// </summary>
    /// <param name="filePath">Path of where to save the file</param>
    /// <param name="fileStream">File stream to save</param>
    /// <returns>The path of the file to where it's saved</returns>
    /// <remarks>
    /// If the file is inside a S3 client, it will return the url to the file
    /// </remarks>
    Task<string> SaveFileAsync(string filePath, Stream fileStream);
    
    /// <summary>
    /// Copies the specified file to the destination path
    /// </summary>
    /// <param name="sourcePath">Path of the file you want to copy</param>
    /// <param name="destinationPath">Path of where you want the file to be copied at</param>
    void CopyFile(string sourcePath, string destinationPath);
}