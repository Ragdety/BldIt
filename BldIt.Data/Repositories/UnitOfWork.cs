using System.Threading.Tasks;
using BldIt.Models.Interfaces;
using Microsoft.Extensions.Logging;

namespace BldIt.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppIdentityDbContext _context;
        private readonly ILogger _logger;

        public UnitOfWork(
            AppIdentityDbContext context, 
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            JobRepo = new JobRepo(context, _logger);
        }

        public IJobRepo JobRepo { get; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}