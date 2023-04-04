using BldIt.Api.Shared.Interfaces;
using BldIt.BuildWorker.Core.Models;
using BldIt.GitHub.Contracts.Contracts;
using MassTransit;

namespace BldIt.BuildWorker.Api.Consumers.GitHub;

public class CreatedGitHubCredential : IConsumer<GitHubCredentialCreated>
{
    private readonly IRepository<WorkerGitHubCredential, Guid> _credentialRepository;
    private readonly ILogger<CreatedGitHubCredential> _logger;

    public CreatedGitHubCredential(IRepository<WorkerGitHubCredential, Guid> credentialRepository, ILogger<CreatedGitHubCredential> logger)
    {
        _credentialRepository = credentialRepository;
        _logger = logger;
    }
    
    public async Task Consume(ConsumeContext<GitHubCredentialCreated> context)
    {
        var message = context.Message;
        
        var existingCredential = await _credentialRepository.GetAsync(c => c.UserId == message.UserId);
        
        //This should eventually never happen, but just in case:
        if (existingCredential is not null)
        {
            _logger.LogWarning("Credential already exists for user {UserId}", message.UserId);
            return;
        }
        
        var credential = new WorkerGitHubCredential
        {
            Id = message.CredentialId,
            AccessToken = message.AccessToken,
            UserId = message.UserId,
            GitHubUserName = message.GitHubUserName
        };
        
        await _credentialRepository.CreateAsync(credential);
        _logger.LogInformation("Created credential for user {UserId}", message.UserId);
    }
}