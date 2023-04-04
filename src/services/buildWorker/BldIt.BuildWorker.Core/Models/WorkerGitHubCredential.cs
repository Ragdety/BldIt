using BldIt.Api.Shared.Interfaces;

namespace BldIt.BuildWorker.Core.Models;

public class WorkerGitHubCredential : IEntity<Guid>
{
    public Guid Id { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedAt { get; init; }
    public string AccessToken { get; set; }
    public Guid UserId { get; set; }
    public string GitHubUserName { get; set; }
}