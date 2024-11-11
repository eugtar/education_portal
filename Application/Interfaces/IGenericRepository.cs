using System.Linq.Expressions;

namespace Application.Interfaces;
public interface IGenericRepository<T> where T : class
{
    // public bool IsExist(Expression<Func<T, bool>> predicate);
    // public T? GetById(int id);
    // public ICollection<T> GetAll();
    // public T FindOne(Expression<Func<T, bool>> predicate);
    // public ICollection<T> FindAll(Expression<Func<T, bool>> predicate);
    // public void Add(T entity);
    // public void AddRange(ICollection<T> entities);
    public Task UpdateAsync(T entity);
    public Task RemoveAsync(T entity);
    public Task RemoveRangeAsync(ICollection<T> entities);
    public Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate);
    public Task<T?> GetByIdAsync(int id);
    public Task<ICollection<T>> GetAllAsync();
    public Task<T?> FindOneAsync(Expression<Func<T, bool>> predicate);
    public Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
    public Task AddAsync(T entity);
    public Task AddRangeAsync(ICollection<T> entities);
}
