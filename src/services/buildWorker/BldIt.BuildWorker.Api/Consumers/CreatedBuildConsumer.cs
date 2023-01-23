using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Contracts.Contracts;
using BldIt.BuildWorker.Core.Models;
using MassTransit;

namespace BldIt.BuildWorker.Api.Consumers;

public class CreatedBuildConsumer : IConsumer<BuildCreated>
{
    private readonly IRepository<WorkerBuild, Guid> _buildRepository;

    public CreatedBuildConsumer(
        IRepository<WorkerBuild, Guid> buildRepository)
    {
        _buildRepository = buildRepository;
    }
    
    public async Task Consume(ConsumeContext<BuildCreated> context)
    {
        var message = context.Message;

        var exists = await _buildRepository.ExistsAsync(message.Id);
        if (exists) return;

        //Will just keep track of which builds are created (Nothing related to their status or result)
        var buildCreated = new WorkerBuild
        {
            Id = message.Id,
            JobId = message.jobId,
            BuildNumber = message.BuildNumber
        };
        
        await _buildRepository.CreateAsync(buildCreated);
    }
}