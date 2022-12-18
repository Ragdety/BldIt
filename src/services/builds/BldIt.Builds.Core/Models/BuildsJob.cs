using BldIt.Api.Shared.Interfaces;

namespace BldIt.Builds.Core.Models;

public class BuildsJob : IEntity<Guid>
{
    public Guid Id { get; set; }
    public bool Deleted { get; set; } = false;
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public string Name { get; set; }
    public int LastBuildNumber { get; set; } = 0;
    public Guid ProjectId { get; set; }
}