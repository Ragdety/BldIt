using BldIt.Api.Shared.Config;

namespace BldIt.Api.Shared.Services.Storage.Clients;

public class S3StorageClient : IStorageClient
{
    private readonly BldItWorkspaceConfig _config;
    
    public S3StorageClient(BldItWorkspaceConfig config)
    {
        _config = config;
    }

    public Task<string> SaveFileAsync(string fileName, Stream fileStream, string? mime)
    {
        //using var client = Client;
        // var request = new PutObjectRequest
        // {
        //     BucketName = _settings.Bucket,
        //     Key = $"{_config.FilesPath()}/{fileName}",
        //     ContentType = mime,
        //     InputStream = fileStream,
        //     CannedACL = S3CannedACL.PublicRead,
        // };
        // await client.PutObjectAsync(request);
        // return ObjectUrl(fileName);

        throw new NotImplementedException();
    }
    
    // private string ObjectUrl(string fileName) =>
    //     $"{_settings.ServiceUrl}/{_settings.Bucket}/{_config.FilesPath()}/{fileName}";

    // private AmazonS3Client Client => new AmazonS3Client(
    //     _settings.AccessKey,
    //     _settings.SecretKey,
    //     new AmazonS3Config
    //     {
    //         ServiceURL = _settings.ServiceUrl,
    //     }
    // );
}