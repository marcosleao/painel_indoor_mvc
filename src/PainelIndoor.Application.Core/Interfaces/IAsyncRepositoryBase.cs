using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PainelIndoor.Application.Core.Interfaces
{
    public interface IAsyncRepositoryBase<T> where T : class
    {
        Task<T> GetByIdAsync(object id, CancellationToken cancellationToken = default);

        //Task<T> GetByCodeAsync(string code, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

        Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task<T> FirstAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task<bool> GetAnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
