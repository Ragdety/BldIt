using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Contracts.Contracts;
using BldIt.Builds.Core.Models;
using MassTransit;

namespace BldIt.Builds.Service.Consumers.Jobs;

public class UpdateBuildNumber : IConsumer<BuildCreated>
{
    private readonly IRepository<BuildsJob, Guid> _jobsRepo;

    public UpdateBuildNumber(IRepository<BuildsJob, Guid> jobsRepo)
    {
        _jobsRepo = jobsRepo;
    }

    public async Task Consume(ConsumeContext<BuildCreated> context)
    {
        var message = context.Message;
        var job = await _jobsRepo.GetAsync(message.jobId);
        
        if (job is null) return;
        
        job.LastBuildNumber = message.BuildNumber;
        await _jobsRepo.UpdateAsync(job);
    }
}