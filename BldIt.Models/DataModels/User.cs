using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BldIt.Models.DataModels
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateJoined { get; set; } = DateTime.Now;

        public ICollection<Project> CreatedProjects { get; set; }
    }
}