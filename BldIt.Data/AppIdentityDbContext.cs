using System;
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
        public DbSet<BuildStep> BuildSteps { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            /*
             * This permits 2 jobs with the same name in different projects
             * But not the same job name within the same projects
             */
            builder.Entity<Job>()
                .HasIndex(j => new { j.JobName, j.ProjectId })
                .IsUnique();
            
            //Ensures Project names are unique
            builder.Entity<Project>()
                .HasIndex(p => p.ProjectName)
                .IsUnique();

            //Rename to Users
            builder.Entity<User>().ToTable("Users");
        }
    }
}