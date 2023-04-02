namespace BldIt.Jobs.Contracts.Contracts;

public record ScmConfigCreated(
    Guid Id, 
    long RepoId, 
    string RepoName, 
    string RepoUrl, 
    string? Branch, 
    Guid GitHubCredentialId, 
    Guid JobConfigId,
    Guid JobId);