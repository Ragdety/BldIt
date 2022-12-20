using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Contracts.Enums;

namespace BldIt.Builds.Core.Models
{
    public class Build : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime CreatedAt { get; init; } = DateTime.Now;
        
        //Status is used WHILE the build is in progress
        public BuildStatus Status { get; set; }
        
        //Can be null while the build is running. But it MUST be set after build is finished.
        //Result is used AFTER the build is finished.
        public BuildResult? Result { get; set; } = null;
        
        public bool Success => Result.Equals(BuildResult.Success);
        public int Number { get; set; }
        public bool IsLatest { get; set; }
        
        public Guid JobId { get; set; }
    }
}