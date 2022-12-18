using BldIt.Api.Shared.Interfaces;
using BldIt.Jobs.Core.Enums;

namespace BldIt.Jobs.Core.Models
{
    public class Job : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; init; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public string Description { get; set; }
        
        public JobType Type { get; set; }
        //public ICollection<BuildStep> BuildSteps { get; set; } = new List<BuildStep>();
        //public ICollection<Build> JobBuilds { get; set; } = new List<Build>();
        
        public Guid LatestJobConfigId { get; set; } = Guid.Empty;
        public Guid LatestBuildConfigId { get; set; } = Guid.Empty;

        public int LastBuildNumber { get; set; } = 0;

        public Guid ProjectId { get; set; }
    }
}