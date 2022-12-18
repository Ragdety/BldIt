using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Core.Enums;

namespace BldIt.Builds.Core.Models
{
    public class Build : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime CreatedAt { get; init; } = DateTime.Now;

        public BuildStatus Status { get; set; }
        public bool Success => Status.Equals(BuildStatus.Success);
        public int Number { get; set; }
        public bool IsLatest { get; set; }
        
        public Guid JobId { get; set; }
    }
}