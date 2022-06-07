using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BldIt.Data;
using BldIt.Models.DataModels;
using BldIt.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BldIt.Api.Repositories
{
    public class JobRepo : GenericRepo<Job>, IJobRepo
    {
        public JobRepo(AppIdentityDbContext context, ILogger logger) : base(context, logger) { }

        public override async Task<IEnumerable<Job>> GetAllAsync()
        {
            try
            {
                return await base.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(JobRepo));
                return new List<Job>();
            }
        }
        
        public override async Task<bool> DeleteAsync(object id)
        {
            try
            {
                var exist = await _dbSet.Where(x => x.Id == (string) id).FirstOrDefaultAsync();
                if (exist == null) return false;
                _dbSet.Remove(exist);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(JobRepo));
                return false;
            }
        }

        public async Task<bool> JobExists(string jobName)
        {
            return await GetByIdAsync(jobName) != null;
        }
    }
}
