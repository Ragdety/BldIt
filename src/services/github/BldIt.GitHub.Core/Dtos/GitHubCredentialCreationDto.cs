namespace BldIt.GitHub.Core.Dtos;

public class GitHubCredentialCreationDto
{
    public string PersonalAccessToken { get; set; }
    public string? Description { get; set; }
}