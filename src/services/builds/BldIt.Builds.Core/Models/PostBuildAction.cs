using BldIt.Api.Shared.Interfaces;

namespace BldIt.Builds.Core.Models;

public class PostBuildAction : IEntity<Guid>
{
    public Guid Id { get; set; }
    public bool Deleted { get; set; } = false;
    public DateTime CreatedAt { get; init; } = DateTime.Now;

    //Will send an email notification if this is true
    public bool EmailNotification { get; set; }
    
    //Will build the job specified (if any)
    public string? JobNameToBuild { get; set; }
    
    //Will upload artifacts into S3 (if selected)
    public bool UploadArtifacts { get; set; }
    public Guid JobId { get; set; }
}