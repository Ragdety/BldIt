using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Core.Models;
using MassTransit;

namespace BldIt.Builds.Service.Consumers.Jobs;

public class JobUpdated : IConsumer<BldIt.Jobs.Contracts.Contracts.JobUpdated>
{
    private readonly IRepository<BuildsJob, Guid> _jobRepository;

    public JobUpdated(IRepository<BuildsJob, Guid> jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task Consume(ConsumeContext<BldIt.Jobs.Contracts.Contracts.JobUpdated> context)
    {
        var message = context.Message;
        
        var job = await _jobRepository.GetAsync(message.JobId);
        if (job == null) return;
        
        job.Name = message.JobName;
        
        await _jobRepository.UpdateAsync(job);
    }
}