using System.ComponentModel.DataAnnotations.Schema;
using BldIt.Models.Abstractions;
using BldIt.Models.Enums;

namespace BldIt.Models.DataModels
{
    public class BuildStep : BaseModel<int>
    {
        public string Command { get; set; }
        public BuildStepType Type { get; set; }
        
        [ForeignKey("JobName")]
        public string JobId { get; set; }
        public virtual Job Job { get; set; }
    }
}