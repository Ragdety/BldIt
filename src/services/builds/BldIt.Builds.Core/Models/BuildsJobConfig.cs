using BldIt.Api.Shared.Interfaces;

namespace BldIt.Builds.Core.Models;

public class BuildsJobConfig : IEntity<Guid>
{
    public Guid Id { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedAt { get; init; }
    
    public Guid JobId { get; set; }
    public string JobWorkspacePath { get; set; }
}