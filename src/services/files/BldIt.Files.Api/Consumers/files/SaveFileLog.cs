using BldIt.BuildWorker.Contracts.Contracts;
using BldIt.Files.Contracts.Contracts;
using IFileProvider = BldIt.Api.Shared.Services.Storage.Providers.IFileProvider;

namespace BldIt.Files.Api.Consumers.files;
using MassTransit;

public class SaveFileLog : IConsumer<BuildLogFileUpdate>
{
    private readonly IFileProvider _fileProvider;
    private readonly IPublishEndpoint _filePublishEndpoint;
    
    public SaveFileLog(IFileProvider fileProvider, IPublishEndpoint filePublishEndpoint)
    {
        _fileProvider = fileProvider;
        _filePublishEndpoint = filePublishEndpoint;
    }
    
    public async Task Consume(ConsumeContext<BuildLogFileUpdate> context)
    {
        var message = context.Message;
    
        _fileProvider.SaveBuildLogFromTemp(message.LogFilePath, message.BuildId.ToString());
        await _filePublishEndpoint.Publish(new UpdateBuildLogFileLocation(message.BuildId, message.LogFilePath));
        
        //DO NOT DO THIS, THIS IS OLD WAY OF THINKING!!!!!
        //IFileProvider provider = new LocalFileProvider();
        //provider.SaveBuildLogFromTemp(message.LogFilePath, message.BuildId.ToString());
    }
}