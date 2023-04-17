using BldIt.Api.Shared.Interfaces;

namespace BldIt.BuildWorker.Core.Models;

public class WorkerJobConfig : IEntity<Guid>
{
    public Guid Id { get; set; }
    public bool Deleted { get; set; } = false;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    
    public Guid JobId { get; set; }
    public string JobWorkspacePath { get; set; }
}