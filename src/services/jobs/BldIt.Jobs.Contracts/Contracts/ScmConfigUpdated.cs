namespace BldIt.Jobs.Contracts.Contracts;

public record ScmConfigUpdated(Guid Id, long RepoId, string RepoName, string? Branch, Guid GitHubCredentialId, Guid JobConfigId);