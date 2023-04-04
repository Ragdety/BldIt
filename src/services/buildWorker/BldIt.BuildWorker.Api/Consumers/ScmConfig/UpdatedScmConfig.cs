using BldIt.Api.Shared.Interfaces;
using BldIt.BuildWorker.Core.Models;
using BldIt.Jobs.Contracts.Contracts;
using MassTransit;

namespace BldIt.BuildWorker.Api.Consumers.ScmConfig;

public class UpdatedScmConfig : IConsumer<ScmConfigUpdated>
{
    private readonly IRepository<WorkerScmConfig, Guid> _scmConfigRepo;
    private readonly ILogger<CreatedScmConfig> _logger;

    public UpdatedScmConfig(IRepository<WorkerScmConfig, Guid> scmConfigRepo, ILogger<CreatedScmConfig> logger)
    {
        _scmConfigRepo = scmConfigRepo;
        _logger = logger;
    }
    
    public async Task Consume(ConsumeContext<ScmConfigUpdated> context)
    {
        var message = context.Message;
        
        var scmConfig = await _scmConfigRepo.GetAsync(message.Id);
        
        if (scmConfig is null)
        {
            _logger.LogWarning("ScmConfig with id {Id} does not exist", message.Id);
            return;
        }
        
        scmConfig.RepoId = message.RepoId;
        scmConfig.RepoName = message.RepoName;
        scmConfig.RepoUrl = message.RepoUrl;
        scmConfig.Branch = message.Branch;
        scmConfig.GitHubCredentialId = message.GitHubCredentialId;
        
        await _scmConfigRepo.UpdateAsync(scmConfig);
    }
}