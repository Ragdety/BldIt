using System;
using System.Linq;
using System.Threading.Tasks;
using BldIt.Models.DataModels;
using BldIt.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BldIt.Data.Repositories
{
    public class JobRepo : GenericRepo<Job>, IJobRepo
    {
        public JobRepo(AppIdentityDbContext context) : base(context) { }

        public override async Task<bool> UpdateAsync(Job job)
        {
            var existingProj = await GetByIdAsync(job.Id);
            if (existingProj == null) return false;
            Context.Entry(job).State = EntityState.Modified;
            return true;
        }

        public async Task<bool> ExistsAsync(Guid projectId, string jobName)
        {
            var project = await Context
                .Set<Project>()
                .Where(p => p.Id == projectId)
                .Include(p => p.Jobs)
                .FirstOrDefaultAsync();

            var job = project?.Jobs.Where(j => j.JobName == jobName);
            return job != null;
        }

        public async Task<Job?> GetByNameAsync(Guid projectId, string jobName)
        {
           return await _dbSet
                .Where(j => j.ProjectId == projectId && j.JobName == jobName)
                .FirstOrDefaultAsync();
        }
    }
}
