using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BldIt.Models.DataModels;
using BldIt.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BldIt.Data.Repositories
{
    public class JobRepo : GenericRepo<Job>, IJobRepo
    {
        public JobRepo(AppIdentityDbContext context, ILogger logger) : base(context, logger) { }

        public override async Task<bool> DeleteAsync(object id)
        {
            var exist = await _dbSet.Where(x => x.Id == (string) id).FirstOrDefaultAsync();
            if (exist == null) return false;
            _dbSet.Remove(exist);
            return true;
        }

        public async Task<bool> JobExists(string jobName) => await GetByIdAsync(jobName) != null;
    }
}
