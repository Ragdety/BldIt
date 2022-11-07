using BldIt.Models.Interfaces;

namespace BldIt.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppIdentityDbContext _context;

        public UnitOfWork(
            AppIdentityDbContext context)
        {
            _context = context;
            JobRepo = new JobRepo(context);
            ProjectRepo = new ProjectRepo(context);
        }

        public IJobRepo JobRepo { get; }
        public IProjectRepo ProjectRepo { get; }
        
        public async Task CompleteAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}