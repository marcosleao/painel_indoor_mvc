using Microsoft.EntityFrameworkCore;
using PainelIndoor.Application.Core.Entities;
using PainelIndoor.Application.Core.Interfaces;
using PainelIndoor.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PainelIndoor.Infra.Data.Repositories
{
    public class EFAsyncRepositoryBase<T> : IAsyncRepositoryBase<T> where T : class
    {
        protected readonly ApplicationDbContext dbContext;

        public EFAsyncRepositoryBase(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().Add(entity);
            await SaveChangesAsync(cancellationToken);
            return entity;
        }

        public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().AddRange(entities);
            await SaveChangesAsync(cancellationToken);
            return entities;
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>()
                .AsNoTrackingWithIdentityResolution()
                .CountAsync(predicate, cancellationToken);
        }

        public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().Remove(entity);
            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().RemoveRange(entities);
            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<T> FirstAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>()
                .AsNoTrackingWithIdentityResolution()
                .FirstAsync(predicate, cancellationToken);
        }

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>()
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public virtual async Task<bool> GetAnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>()
                .AsNoTrackingWithIdentityResolution()
                .AnyAsync(predicate, cancellationToken);
        }

        //public Task<T> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        public virtual async Task<T> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken);
        }

        public Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().Update(entity);
            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
