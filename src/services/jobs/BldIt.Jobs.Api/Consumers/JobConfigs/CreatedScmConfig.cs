using BldIt.Api.Shared.Interfaces;
using BldIt.Jobs.Contracts.Contracts;
using BldIt.Jobs.Core.Models;
using MassTransit;

namespace BldIt.Jobs.Api.Consumers.JobConfigs;

public class CreatedScmConfig : IConsumer<ScmConfigCreated>
{
    private readonly IRepository<JobConfig, Guid> _jobConfigsRepo;
    private readonly ILogger<CreatedScmConfig> _logger;

    public CreatedScmConfig(IRepository<JobConfig, Guid> jobConfigsRepo, ILogger<CreatedScmConfig> logger)
    {
        _jobConfigsRepo = jobConfigsRepo;
        _logger = logger;
    }
    
    public async Task Consume(ConsumeContext<ScmConfigCreated> context)
    {
        var message = context.Message;
        
        var jobConfig = await _jobConfigsRepo.GetAsync(message.JobConfigId);
        if (jobConfig is null)
        {
            _logger.LogWarning($"Job config with id {message.JobConfigId} not found");
            _logger.LogWarning($"Scm config with id {message.Id} not mapped to job config");
            return;
        }
        
        //Update the job config with the new scm config id
        jobConfig.ScmConfigId = message.Id;
        await _jobConfigsRepo.UpdateAsync(jobConfig);
    }
}