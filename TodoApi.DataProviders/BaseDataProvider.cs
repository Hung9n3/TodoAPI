using Contracts.DataProviders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Core.Database;
using TodoApi.Core.Entities;
using TodoApi.DataProviders.Extensions;

namespace TodoApi.DataProviders
{
    public class BaseDataProvider<T> : IBaseDataProvider<T> where T : BaseEntity
    {
        protected readonly TodoContext _context;
        protected readonly DbSet<T> _dbSet;
        public BaseDataProvider(TodoContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual IQueryable<T> FindAll(Expression<Func<T, bool>>? predicate = null)
            => _dbSet.WhereIf(predicate != null, predicate!);

        public virtual async Task<T?> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public virtual async Task<T?> FindByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(name, cancellationToken);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<T>> FindByListIdAsync(List<int> id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(x => id.Contains(x.Id)).ToListAsync();
        }
    }
}
