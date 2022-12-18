using BldIt.Api.Shared.Interfaces;

namespace BldIt.Jobs.Core.Models;

public class JobsProject : IEntity<Guid>
{
    public Guid Id { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public string ProjectWorkspacePath { get; set; }
}