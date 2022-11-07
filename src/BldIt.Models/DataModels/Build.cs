using BldIt.Models.Abstractions;
using BldIt.Models.Enums;

namespace BldIt.Models.DataModels
{
    public class Build : BaseModel<int>
    {
        public BuildStatus BuildStatus { get; set; }
        public bool Success => BuildStatus.Equals(BuildStatus.Passed);

        public Guid JobId { get; set; }
        public virtual Job Job { get; set; }
    }
}