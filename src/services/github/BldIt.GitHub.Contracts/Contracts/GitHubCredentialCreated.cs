namespace BldIt.GitHub.Contracts.Contracts;

public record GitHubCredentialCreated(Guid CredentialId, string AccessToken, Guid UserId, string GitHubUserName);