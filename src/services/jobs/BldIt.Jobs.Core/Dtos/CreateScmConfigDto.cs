namespace BldIt.Jobs.Core.Dtos;

public class CreateScmConfigDto
{
    public long RepoId { get; set; }
    public string RepoName { get; set; }
    public string RepoUrl { get; set; }
    public string? Branch { get; set; } = null;
    public Guid GitHubCredentialId { get; set; }
}