using BldIt.Builds.Contracts.Contracts;
using BldIt.Jobs.Core.Repos;
using MassTransit;

namespace BldIt.Jobs.Api.Consumers.Builds;

public class UpdateLatestBuildConfigConsumer : IConsumer<UpdateLatestBuildConfig>
{
    private readonly IJobsRepo _jobsRepo;

    public UpdateLatestBuildConfigConsumer(IJobsRepo jobsRepo)
    {
        _jobsRepo = jobsRepo;
    }

    public async Task Consume(ConsumeContext<UpdateLatestBuildConfig> context)
    {
        var message = context.Message;
        var job = await _jobsRepo.GetAsync(message.JobId);

        if (job is null) return;
        
        job.LatestBuildConfigId = message.BuildConfigId;
        await _jobsRepo.UpdateAsync(job);
    }
}