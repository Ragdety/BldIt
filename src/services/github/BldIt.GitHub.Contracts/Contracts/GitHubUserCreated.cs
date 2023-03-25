namespace BldIt.GitHub.Contracts.Contracts;

public record GitHubUserCreated(string Id, string Login, string Name, string Url, Guid BldItUserId);