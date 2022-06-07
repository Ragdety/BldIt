using System;
using System.Collections.Generic;
using BldIt.Models.Abstractions;
using BldIt.Models.Enums;

namespace BldIt.Models.DataModels
{
    public class Job : BaseModel<string>
    {
        public string JobDescription { get; set; }
        public string? JobWorkspacePath { get; set; }
        public DateTime UpdatedAt { get; set; }
        public JobType JobType { get; set; }
        public ICollection<BuildStep> BuildSteps { get; set; } = new List<BuildStep>();
        public ICollection<Build> JobBuilds { get; set; } = new List<Build>();
    }
}