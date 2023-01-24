using BldIt.Builds.Contracts.Contracts;
using BldIt.BuildScheduler.Contracts.Contracts;
using BldIt.BuildScheduler.Core.Interfaces;
using MassTransit;

namespace BldIt.BuildScheduler.Api.Consumers;

public class BuildRequestConsumer : IConsumer<BuildRequest>
{
    private readonly IBuildQueue _buildQueue;
    private readonly ILogger<BuildRequestConsumer> _logger;
    private readonly IPublishEndpoint _publishEndpoint;

    public BuildRequestConsumer(
        IBuildQueue buildQueue, 
        ILogger<BuildRequestConsumer> logger, 
        IPublishEndpoint publishEndpoint)
    {
        _buildQueue = buildQueue;
        _logger = logger;
        _publishEndpoint = publishEndpoint;
    }
    
    public Task Consume(ConsumeContext<BuildRequest> context)
    {
        var message = context.Message;
        
        _logger.LogInformation("Attempting to queue build request {Request}", message);
        
        _buildQueue.QueueBuild(async token =>
        {
            await _publishEndpoint.Publish(new StartBuildRequest(message.BuildId, message.BuildConfigId, message.BuildNumber), token);
        });

        return Task.CompletedTask;
    }
}