using BldIt.Api.Shared.Interfaces;

namespace BldIt.GitHub.Core.Models;

public class GitHubCredential : IEntity<Guid>
{
    public Guid Id { get; set; }
    public bool Deleted { get; set; } = false;
    public DateTime CreatedAt { get; init; } = DateTime.Now;

    public string? Description { get; set; }
    
    //GitHub Token
    public string AccessToken { get; set; }
    
    //To which BldIt user does this credential belong to
    public Guid UserId { get; set; }
    
    //GitHub user information, maps to GitHubUser entity
    public string GitHubUserId { get; set; }
}