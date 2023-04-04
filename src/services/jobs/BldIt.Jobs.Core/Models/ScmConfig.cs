using BldIt.Api.Shared.Interfaces;

namespace BldIt.Jobs.Core.Models;

public class ScmConfig : IEntity<Guid>
{
    public Guid Id { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedAt { get; init; }

    public long RepoId { get; set; }
    public string RepoName { get; set; }
    public string RepoUrl { get; set; }
    public string? Branch { get; set; }
    
    //In order to map this config to a credential and job config
    public Guid GitHubCredentialId { get; set; }
    public Guid JobConfigId { get; set; }
    public Guid JobId { get; set; }
}