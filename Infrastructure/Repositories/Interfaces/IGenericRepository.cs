using Domain;

namespace Infrastructure
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T? GetById(string id);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(string id);
    }
}
