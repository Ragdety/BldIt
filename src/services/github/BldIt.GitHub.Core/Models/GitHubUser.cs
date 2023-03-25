using BldIt.Api.Shared.Interfaces;

namespace BldIt.GitHub.Core.Models;

public class GitHubUser : IEntity<string>
{
    public string Id { get; set; }
    public bool Deleted { get; set; } = false;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    
    public string Login { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }

    public Guid BldItUserId { get; set; }
}