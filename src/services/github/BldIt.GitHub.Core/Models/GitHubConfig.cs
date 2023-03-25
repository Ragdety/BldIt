using BldIt.Api.Shared.Interfaces;

namespace BldIt.GitHub.Core.Models;

public class GitHubConfig : IEntity<Guid>
{
    public Guid Id { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedAt { get; init; }

    //GitHub repo URL
    public string RepositoryUrl { get; set; }

    //To which job does this config belong to
    public Guid JobId { get; set; }
}