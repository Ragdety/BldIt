using BldIt.Jobs.Contracts.Contracts;
using BldIt.Jobs.Core.Repos;
using MassTransit;

namespace BldIt.Jobs.Api.Consumers.Jobs;

public class UpdateLatestJobConfigConsumer : IConsumer<UpdateLatestJobConfig>
{
    private readonly IJobsRepo _jobsRepo;
    
    public UpdateLatestJobConfigConsumer(IJobsRepo jobsRepo)
    {
        _jobsRepo = jobsRepo;
    }
    
    public async Task Consume(ConsumeContext<UpdateLatestJobConfig> context)
    {
        var message = context.Message;
        var job = await _jobsRepo.GetAsync(message.JobId);
        
        if (job is null) return;
        
        job.LatestJobConfigId = message.JobConfigId;
        await _jobsRepo.UpdateAsync(job);
    }
}