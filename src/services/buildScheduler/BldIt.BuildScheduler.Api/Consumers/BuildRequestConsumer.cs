using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Contracts.Contracts;
using BldIt.BuildScheduler.Contracts.Contracts;
using MassTransit;

namespace BldIt.BuildScheduler.Api.Consumers;

public class BuildRequestConsumer : IConsumer<BuildRequest>
{
    private readonly IBldItQueue<Func<CancellationToken, Task>> _buildQueue;
    private readonly ILogger<BuildRequestConsumer> _logger;
    private readonly IPublishEndpoint _publishEndpoint;

    public BuildRequestConsumer(
        IBldItQueue<Func<CancellationToken, Task>> buildQueue, 
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
        
        _buildQueue.Queue(async token =>
        {
            await _publishEndpoint.Publish(new StartBuildRequest(message.BuildId, message.BuildConfigId, message.BuildNumber), token);
        });

        return Task.CompletedTask;
    }
}