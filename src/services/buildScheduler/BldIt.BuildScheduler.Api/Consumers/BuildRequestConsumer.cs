using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Contracts.Contracts;
using BldIt.Builds.Contracts.Keys;
using BldIt.BuildScheduler.Contracts.Contracts;
using BldIt.BuildScheduler.Core.Interfaces;
using BldIt.BuildScheduler.Core.Models;
using MassTransit;

namespace BldIt.BuildScheduler.Api.Consumers;

public class BuildRequestConsumer : IConsumer<BuildRequest>
{
    private readonly IRepository<SchedulerBuildStep, BuildStepKey> _buildStepsRepository;
    private readonly IBuildQueue _buildQueue;
    private readonly ILogger<BuildRequestConsumer> _logger;
    private readonly IPublishEndpoint _publishEndpoint;

    public BuildRequestConsumer(
        IRepository<SchedulerBuildStep, BuildStepKey> buildStepsRepository,
        IBuildQueue buildQueue, 
        ILogger<BuildRequestConsumer> logger, 
        IPublishEndpoint publishEndpoint)
    {
        _buildStepsRepository = buildStepsRepository;
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
            await _publishEndpoint.Publish(new StartBuildRequest(message.BuildConfigId), token);
            // await _buildManager.StartBuildAsync(message, token);
        });
        
        return Task.CompletedTask;
    }
}