namespace BldIt.Api.Shared.Services.Storage.Clients;

public interface IStorageClient
{
    /// <summary>
    /// Store and save the file with the given name
    /// </summary>
    /// <param name="fileName">Name of the file to save</param>
    /// <param name="fileStream">File stream to save</param>
    /// <param name="mime">Optional mime in case any storage client requires it</param>
    /// <returns>The path of the file to where it's saved</returns>
    /// <remarks>
    /// If the file is inside a S3 client, it will return the url to the file
    /// </remarks>
    Task<string> SaveFileAsync(string fileName, Stream fileStream, string? mime = null);
}