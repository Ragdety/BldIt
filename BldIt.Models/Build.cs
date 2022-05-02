using BldIt.Models.Abstractions;
using BldIt.Models.Enums;

namespace BldIt.Models
{
    public class Build : BaseModel<int>
    {
        public BuildStatus BuildStatus { get; set; }
        public bool Success => BuildStatus.Equals(BuildStatus.Passed);

        public Job Job { get; set; }
    }
}