using BldIt.BuildWorker.Contracts.Contracts;
using BldIt.BuildWorker.Core.Interfaces;
using MassTransit;

namespace BldIt.BuildWorker.Api.Consumers;

public class UpdateBuildResult : IConsumer<BuildResultUpdated>
{
    private readonly IBuildWorkerManager _buildWorkerManager;
    
    public UpdateBuildResult(
        IBuildWorkerManager buildWorkerManager)
    {
        _buildWorkerManager = buildWorkerManager;
    }
    
    //This consumer listens for builds that have finished execution
    public async Task Consume(ConsumeContext<BuildResultUpdated> context)
    {
        var message = context.Message;
        await _buildWorkerManager.RemoveActiveWorkerAsync(message.BuildId);
    }
}