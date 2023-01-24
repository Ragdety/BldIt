using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Contracts.Contracts;
using BldIt.Builds.Contracts.Keys;
using BldIt.BuildScheduler.Contracts.Contracts;
using BldIt.BuildWorker.Core.Interfaces;
using BldIt.BuildWorker.Core.Models;
using MassTransit;

namespace BldIt.BuildWorker.Api.Consumers;

public class BuildStartConsumer : IConsumer<StartBuildRequest>
{
    private readonly ILogger<BuildStartConsumer> _logger;
    private readonly IBuildWorkerManager _buildWorkerManager;

    public BuildStartConsumer(
        ILogger<BuildStartConsumer> logger, 
        IBuildWorkerManager buildWorkerManager)
    {
        _logger = logger;
        _buildWorkerManager = buildWorkerManager;
    }
    
    public async Task Consume(ConsumeContext<StartBuildRequest> context)
    {
        var message = context.Message;
        
        _logger.LogInformation("Attempting to start build {Request}", message);
        
        //Allocate a worker to the build request 
        var worker = _buildWorkerManager.AddActiveWorker(message.BuildId);
        
        //Start the build
        //Cancellation token is none since at this point build has been requested to start
        await worker.StartBuildAsync(message, CancellationToken.None);
    }
}