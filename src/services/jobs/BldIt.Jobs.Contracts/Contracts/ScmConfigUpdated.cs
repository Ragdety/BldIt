namespace BldIt.Jobs.Contracts.Contracts;

public record ScmConfigUpdated(Guid Id, long RepoId, string RepoName, string RepoUrl, string? Branch, Guid GitHubCredentialId);