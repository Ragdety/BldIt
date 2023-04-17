using BldIt.Api.Shared.Interfaces;
using BldIt.BuildWorker.Core.Models;
using BldIt.Jobs.Contracts.Contracts;
using MassTransit;

namespace BldIt.BuildWorker.Api.Consumers.JobConfigs;

public class CreatedJobConfig : IConsumer<JobConfigCreated>
{
    private readonly IRepository<WorkerJobConfig, Guid> _workerJobConfigRepo;

    public CreatedJobConfig(IRepository<WorkerJobConfig, Guid> workerJobConfigRepo)
    {
        _workerJobConfigRepo = workerJobConfigRepo;
    }
    
    public async Task Consume(ConsumeContext<JobConfigCreated> context)
    {
        var message = context.Message;
        
        var config = await _workerJobConfigRepo.GetAsync(message.JobConfigId);
        
        if(config is not null) return;
        
        var newConfig = new WorkerJobConfig
        {
            Id = message.JobConfigId,
            JobId = message.JobId,
            JobWorkspacePath = message.JobWorkspacePath
        };
        
        await _workerJobConfigRepo.CreateAsync(newConfig);
    }
}