using System;
using BldIt.Models;
using BldIt.Models.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BldIt.Data
{
    public class AppIdentityDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options) { }
        
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Build> Builds { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Job>()
                .Property(e => e.Id).HasColumnName("JobName");
            builder.Entity<Build>()
                .Property(e => e.JobId).HasColumnName("JobName");
            builder.Entity<BuildStep>()
                .Property(e => e.JobId).HasColumnName("JobName");
            
            base.OnModelCreating(builder);
        }
    }
}