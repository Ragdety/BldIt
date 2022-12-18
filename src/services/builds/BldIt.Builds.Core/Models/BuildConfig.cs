using BldIt.Api.Shared.Interfaces;

namespace BldIt.Builds.Core.Models;

public class BuildConfig : IEntity<Guid>
{
    public Guid Id { get; set; }
    public bool Deleted { get; set; } = false;
    public DateTime CreatedAt { get; init; } = DateTime.Now;

    //To which job this build config belongs
    public Guid JobId { get; set; }
}