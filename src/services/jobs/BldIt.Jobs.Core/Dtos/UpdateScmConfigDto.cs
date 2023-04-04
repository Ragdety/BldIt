namespace BldIt.Jobs.Core.Dtos;

public class UpdateScmConfigDto
{
    public long RepoId { get; set; }
    public string RepoName { get; set; }
    public string RepoUrl { get; set; }
    public string? Branch { get; set; }
    public Guid GitHubCredentialId { get; set; }
}