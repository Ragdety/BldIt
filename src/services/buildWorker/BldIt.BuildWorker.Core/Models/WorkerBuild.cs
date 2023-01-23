using BldIt.Api.Shared.Interfaces;

namespace BldIt.BuildWorker.Core.Models;

public class WorkerBuild : IEntity<Guid>
{
    public Guid Id { get; set; }
    public bool Deleted { get; set; } = false;
    public DateTime CreatedAt { get; init; } = DateTime.Now;

    public int BuildNumber { get; set; }
    public Guid JobId { get; set; }
}