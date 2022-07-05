using System;

namespace BldIt.Models.DataModels
{
    public class UserProject
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}