using System;
using System.Collections.Generic;
using BldIt.Models.Abstractions;

namespace BldIt.Models
{
    public class Job : BaseModel<Guid>
    {
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<BuildStep> BuildSteps { get; set; }
        public ICollection<Build> JobBuilds { get; set; }
    }
}