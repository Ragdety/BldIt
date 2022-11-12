namespace BldIt.Api.Shared.Settings;

public class MongoDbSettings
{
    public string Name { get; set; }
    public string Host { get; init; }
    public int Port { get; init; }
    public string ConnectionString => $"mongodb://{Host}:{Port}";
}