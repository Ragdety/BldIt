using BldIt.Api.Shared.Interfaces;

namespace BldIt.Jobs.Core.Models;

public abstract class JobConfig : IEntity<Guid>
{
    protected JobConfig()
    {
        
    }
    
    //General information about job configuration
    public Guid Id { get; set; }
    public bool Deleted { get; set; } = false;
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    
    public string? JobWorkspacePath { get; set; }
    public Guid JobId { get; set; }

    //Null if no SCM is configured, this will be set if GitHub is configured
    public Guid? ScmId { get; set; } = null;
}