using BldIt.Models.Abstractions;
using BldIt.Models.Enums;

namespace BldIt.Models
{
    public class BuildStep : BaseModel<int>
    {
        public string Command { get; set; }
        public BuildStepType Type { get; set; }
        //public Job Job { get; set; }
    }
}