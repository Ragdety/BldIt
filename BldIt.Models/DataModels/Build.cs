using System.ComponentModel.DataAnnotations.Schema;
using BldIt.Models.Abstractions;
using BldIt.Models.Enums;

namespace BldIt.Models.DataModels
{
    public class Build : BaseModel<int>
    {
        public BuildStatus BuildStatus { get; set; }
        public bool Success => BuildStatus.Equals(BuildStatus.Passed);

        [ForeignKey("JobName")]
        public string JobId { get; set; }
        public virtual Job Job { get; set; }
    }
}