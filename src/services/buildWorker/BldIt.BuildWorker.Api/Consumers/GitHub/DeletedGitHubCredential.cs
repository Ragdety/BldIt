using BldIt.Api.Shared.Interfaces;
using BldIt.BuildWorker.Core.Models;
using BldIt.GitHub.Contracts.Contracts;
using MassTransit;

namespace BldIt.BuildWorker.Api.Consumers.GitHub;

public class DeletedGitHubCredential : IConsumer<GitHubCredentialDeleted>
{
    private readonly IRepository<WorkerGitHubCredential, Guid> _credentialRepository;
    private readonly ILogger<CreatedGitHubCredential> _logger;

    public DeletedGitHubCredential(IRepository<WorkerGitHubCredential, Guid> credentialRepository, ILogger<CreatedGitHubCredential> logger)
    {
        _credentialRepository = credentialRepository;
        _logger = logger;
    }
    
    public async Task Consume(ConsumeContext<GitHubCredentialDeleted> context)
    {
        var message = context.Message;
        
        var existingCredential = await _credentialRepository.GetAsync(message.Id);
        
        //This should eventually never happen, but just in case:
        if (existingCredential is null)
        {
            _logger.LogWarning("Credential {CredId} does not exist", message.Id);
            return;
        }
        
        await _credentialRepository.RemoveAsync(existingCredential.Id);
    }
}