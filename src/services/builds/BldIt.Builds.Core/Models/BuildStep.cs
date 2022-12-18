using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Core.Enums;
using BldIt.Builds.Core.Keys;

namespace BldIt.Builds.Core.Models;

public class BuildStep : IEntity<BuildStepKey>
{
    public BuildStepKey Id { get; set; }
    public bool Deleted { get; set; } = false;
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    
    public string Command { get; set; }
    public BuildStepType Type { get; set; }
}