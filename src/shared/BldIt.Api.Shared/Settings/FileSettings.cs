namespace BldIt.Api.Shared.Settings;

public class FileSettings
{
    /// <summary>
    /// Type of file provider (local, S3, etc)
    /// </summary>
    public string Provider { get; set; }
    
    /// <summary>
    /// Represents the home path of bldIt  
    /// </summary>
    /// <remarks>
    /// If running locally, this will be a custom path in the computer
    /// If running on S3, this will be the root of the S3 bucket
    /// </remarks>
    public string BldItHome { get; set; }
}