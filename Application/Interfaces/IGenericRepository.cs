using System.Linq.Expressions;

namespace Application.Interfaces;
public interface IGenericRepository<T> where T : class
{
    public ICollection<T> GetAll();
    public ICollection<T> Find(Expression<Func<T, bool>> predicate);
    public T? GetById(int id);
    public void Add(T entity);
    public void AddRange(T entities);
    public void Update(T entity);
    public void Remove(T entity);
    public void RemoveRange(T entities);
}
