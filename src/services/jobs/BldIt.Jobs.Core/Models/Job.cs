using BldIt.Api.Shared.Interfaces;
using BldIt.Jobs.Core.Enums;

namespace BldIt.Jobs.Core.Models
{
    public class Job : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public string? JobWorkspacePath { get; set; }
        public DateTime UpdatedAt { get; set; }
        public JobType JobType { get; set; }
        //public ICollection<BuildStep> BuildSteps { get; set; } = new List<BuildStep>();
        //public ICollection<Build> JobBuilds { get; set; } = new List<Build>();
        public Guid ProjectId { get; set; }
    }
}