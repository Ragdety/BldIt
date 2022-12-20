using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Contracts.Contracts;
using BldIt.Builds.Contracts.Keys;
using BldIt.BuildScheduler.Api.Hubs;
using BldIt.BuildScheduler.Core.Interfaces;
using BldIt.BuildScheduler.Core.Models;
using MassTransit;
using Microsoft.AspNetCore.SignalR;

namespace BldIt.BuildScheduler.Api.Consumers;

public class BuildRequestConsumer : IConsumer<BuildRequest>
{
    private readonly IRepository<SchedulerBuildStep, BuildStepKey> _buildStepsRepository;
    private readonly IHubContext<BuildStreamHub> _hub;
    private readonly IBuildQueue _buildQueue;
    private readonly IBuildManager _buildManager;
    private readonly ILogger<BuildRequestConsumer> _logger;

    public BuildRequestConsumer(
        IRepository<SchedulerBuildStep, BuildStepKey> buildStepsRepository,
        IHubContext<BuildStreamHub> hub, 
        IBuildQueue buildQueue, 
        IBuildManager buildManager, 
        ILogger<BuildRequestConsumer> logger)
    {
        _buildStepsRepository = buildStepsRepository;
        _hub = hub;
        _buildQueue = buildQueue;
        _buildManager = buildManager;
        _logger = logger;
    }
    
    public Task Consume(ConsumeContext<BuildRequest> context)
    {
        var message = context.Message;
        
        _logger.LogInformation("Attempting to queue build request {Request}", message);
        
        _buildQueue.QueueBuild(async token =>
        {
            await _buildManager.StartBuildAsync(message, token);
        });
        
        return Task.CompletedTask;
    }
}