using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Contracts.Enums;

namespace BldIt.Builds.Core.Models;

public class BuildStep : IEntity<Guid>
{
    public Guid Id { get; set; }
    public bool Deleted { get; set; } = false;
    public DateTime CreatedAt { get; init; } = DateTime.Now;

    public Guid BuildConfigId { get; set; }
    public int Number { get; set; }
    
    public string Command { get; set; }
    public BuildStepType Type { get; set; }
}