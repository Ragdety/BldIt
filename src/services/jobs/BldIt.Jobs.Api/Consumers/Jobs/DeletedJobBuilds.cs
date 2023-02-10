using BldIt.Builds.Contracts.Contracts;
using BldIt.Jobs.Core.Repos;
using MassTransit;

namespace BldIt.Jobs.Api.Consumers.Jobs;

public class DeletedJobBuilds : IConsumer<JobBuildsDeleted>
{
    private readonly IJobsRepo _jobsRepo;
    
    public DeletedJobBuilds(IJobsRepo jobsRepo)
    {
        _jobsRepo = jobsRepo;
    }
    
    public async Task Consume(ConsumeContext<JobBuildsDeleted> context)
    {
        var message = context.Message;
        var job = await _jobsRepo.GetAsync(message.JobId);
        
        if (job is null) return;
        
        //Since no builds exist anymore, then the last build number is 0
        job.LastBuildNumber = 0;
        await _jobsRepo.UpdateAsync(job);
    }
}