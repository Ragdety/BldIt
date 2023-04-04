namespace BldIt.GitHub.Core.ViewModels;

public class GitHubCredentialView
{
    public Guid Id { get; set; }
    public bool Deleted { get; set; } = false;
    public DateTime CreatedAt { get; init; } = DateTime.Now;

    public string? Description { get; set; }
    public Guid UserId { get; set; }
    public string GitHubUserId { get; set; }
    public string GitHubUserName { get; set; }
}