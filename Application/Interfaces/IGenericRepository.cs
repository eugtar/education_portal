using System.Linq.Expressions;
using Domain.Common;

namespace Application.Interfaces;
public interface IGenericRepository<T> where T : BaseEntity
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
