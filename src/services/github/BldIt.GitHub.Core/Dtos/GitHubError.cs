namespace BldIt.GitHub.Core.Dtos;

public class GitHubError
{
    public string Message { get; set; }
    public string? DocumentationUrl { get; set; }
    public IEnumerable<GitHubErrorItem> Errors { get; set; } = new List<GitHubErrorItem>();
}