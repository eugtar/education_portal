using System.Linq.Expressions;

namespace Application.Interfaces;
public interface IGenericRepository<T> where T : class
{
    public Task UpdateAsync(T entity);
    public Task RemoveAsync(T entity);
    public Task RemoveRangeAsync(IEnumerable<T> entities);
    public Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate);
    public Task<T?> GetByIdAsync(int id);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T?> FindOneAsync(Expression<Func<T, bool>> predicate);
    public Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
    public Task AddAsync(T entity);
    public Task AddRangeAsync(IEnumerable<T> entities);
}
