using BldIt.Jobs.Core.Repos;
using MassTransit;

namespace BldIt.Jobs.Api.Consumers.Builds;

public class BuildCreated : IConsumer<BldIt.Builds.Contracts.Contracts.BuildCreated>
{
    private readonly IJobsRepo _jobsRepo;
    
    public BuildCreated(IJobsRepo jobsRepo)
    {
        _jobsRepo = jobsRepo;
    }
    
    public async Task Consume(ConsumeContext<BldIt.Builds.Contracts.Contracts.BuildCreated> context)
    {
        var message = context.Message;
        var job = await _jobsRepo.GetAsync(message.jobId);
        
        if (job is null) return;
        
        job.LastBuildNumber = message.BuildNumber;
        await _jobsRepo.UpdateAsync(job);
    }
}