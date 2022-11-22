using BldIt.Api.Shared.Interfaces;

namespace BldIt.Jobs.Core.Models;

public class JobsProject : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string ProjectWorkspacePath { get; set; }
}