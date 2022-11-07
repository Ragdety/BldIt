using BldIt.Models.Abstractions;
using BldIt.Models.Enums;

namespace BldIt.Models.DataModels
{
    public class BuildStep : BaseModel<int>
    {
        public string Command { get; set; }
        public BuildStepType Type { get; set; }
        
        public Guid JobId { get; set; }
        public virtual Job Job { get; set; }
    }
}