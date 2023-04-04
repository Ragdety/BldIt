using BldIt.Api.Shared.Interfaces;

namespace BldIt.BuildWorker.Core.Models;

public class WorkerScmConfig : IEntity<Guid>
{
    public Guid Id { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedAt { get; init; }

    public long RepoId { get; set; }
    public string RepoName { get; set; }
    public string RepoUrl { get; set; }
    public string? Branch { get; set; }
    
    public Guid GitHubCredentialId { get; set; }
    public Guid JobConfigId { get; set; }
    public Guid JobId { get; set; }
}