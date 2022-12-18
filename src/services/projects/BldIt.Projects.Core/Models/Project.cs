using BldIt.Api.Shared.Interfaces;

namespace BldIt.Projects.Core.Models
{
    public class Project : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; init; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public string ProjectName { get; set; }
        public string ProjectWorkspacePath { get; set; }
        //public ICollection<Job> Jobs { get; set; } = new List<Job>();
        public Guid CreatorId { get; set; }
    }
}