using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BldIt.Data;
using BldIt.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BldIt.Api.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected AppIdentityDbContext _context;
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        public GenericRepo(
            AppIdentityDbContext context, 
            ILogger logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(object? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
    }
}