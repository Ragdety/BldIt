using BldIt.Api.Shared.Interfaces;
using BldIt.BuildWorker.Core.Models;
using BldIt.Jobs.Contracts.Contracts;
using MassTransit;

namespace BldIt.BuildWorker.Api.Consumers.ScmConfig;

public class CreatedScmConfig : IConsumer<ScmConfigCreated>
{
    private readonly IRepository<WorkerScmConfig, Guid> _scmConfigRepo;
    private readonly ILogger<CreatedScmConfig> _logger;

    public CreatedScmConfig(IRepository<WorkerScmConfig, Guid> scmConfigRepo, ILogger<CreatedScmConfig> logger)
    {
        _scmConfigRepo = scmConfigRepo;
        _logger = logger;
    }
    
    public async Task Consume(ConsumeContext<ScmConfigCreated> context)
    {
        var message = context.Message;
        
        var scmConfigExists = await _scmConfigRepo.ExistsAsync(message.Id);
        
        if (scmConfigExists)
        {
            _logger.LogWarning("ScmConfig with id {Id} already exists", message.Id);
            return;
        }
        
        var scmConfig = new WorkerScmConfig
        {
            Id = message.Id,
            RepoId = message.RepoId,
            RepoName = message.RepoName,
            RepoUrl = message.RepoUrl,
            Branch = message.Branch,
            GitHubCredentialId = message.GitHubCredentialId,
            JobConfigId = message.JobConfigId,
            JobId = message.JobId
        };
        
        await _scmConfigRepo.CreateAsync(scmConfig);
    }
}