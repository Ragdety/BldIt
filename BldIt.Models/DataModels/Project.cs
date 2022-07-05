using System;
using System.Collections.Generic;
using BldIt.Models.Abstractions;

namespace BldIt.Models.DataModels
{
    public class Project : BaseModel<Guid>
    {
        public Project()
        {
            Id = new Guid();
        }
        
        public string ProjectName { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ProjectWorkspacePath { get; set; }
        public ICollection<Job> Jobs { get; set; } = new List<Job>();
        public Guid CreatorId { get; set; }
        public User Creator { get; set; }
    }
}