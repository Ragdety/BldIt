using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Core.Models;
using BldIt.Jobs.Contracts.Contracts;
using MassTransit;

namespace BldIt.Builds.Service.Consumers.JobsConfig;

public class CreatedJobConfig : IConsumer<JobConfigCreated>
{
    private readonly IRepository<BuildsJobConfig, Guid> _workerJobConfigRepo;

    public CreatedJobConfig(IRepository<BuildsJobConfig, Guid> workerJobConfigRepo)
    {
        _workerJobConfigRepo = workerJobConfigRepo;
    }
    
    public async Task Consume(ConsumeContext<JobConfigCreated> context)
    {
        var message = context.Message;
        
        var config = await _workerJobConfigRepo.GetAsync(message.JobConfigId);
        
        if(config is not null) return;
        
        var newConfig = new BuildsJobConfig
        {
            Id = message.JobConfigId,
            JobId = message.JobId,
            JobWorkspacePath = message.JobWorkspacePath
        };
        
        await _workerJobConfigRepo.CreateAsync(newConfig);
    }
}