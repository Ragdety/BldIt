using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Contracts.Enums;

namespace BldIt.BuildWorker.Core.Models;

public class WorkerBuildStep : IEntity<Guid>
{
    public Guid Id { get; set; }
    public bool Deleted { get; set; } = false;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    public Guid BuildConfigId { get; set; }
    public int BuildStepNumber { get; set; }
    
    public string Command { get; set; }
    public BuildStepType Type { get; set; }
}