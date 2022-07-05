using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BldIt.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BldIt.Data.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected readonly AppIdentityDbContext Context;
        internal DbSet<T> _dbSet;

        public GenericRepo(AppIdentityDbContext context)
        {
            Context = context;
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

        public virtual async Task<T?> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(object id)
        {
            var exist = await GetByIdAsync(id);
            if (exist == null) return false;
            _dbSet.Remove(exist);
            return true;
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            EntityEntry entityEntry = Context.Entry(entity);
            entityEntry.State = EntityState.Modified;
            await Task.CompletedTask;
            return true;
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
        
        public virtual async Task<bool> ExistsAsync(object id) => await GetByIdAsync(id) != null;
    }
}