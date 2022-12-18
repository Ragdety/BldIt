using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Core.Models;
using MassTransit;

namespace BldIt.Builds.Service.Consumers;

public class JobCreated : IConsumer<Jobs.Contracts.Contracts.JobCreated>
{
    private readonly IRepository<BuildsJob, Guid> _jobRepository;

    public JobCreated(IRepository<BuildsJob, Guid> jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task Consume(ConsumeContext<Jobs.Contracts.Contracts.JobCreated> context)
    {
        var message = context.Message;
        
        var exists = await _jobRepository.ExistsAsync(message.Id);
        if (exists) return;
        
        var job = new BuildsJob
        {
            Id = message.Id, 
            Name = message.JobName,
            ProjectId = message.ProjectId
        };

        await _jobRepository.CreateAsync(job);
    }
}