
using Domain;

namespace Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly JsonReader<T> _reader;

        public GenericRepository(string entityName)
        {
            _reader = new JsonReader<T>(entityName);
        }


        public bool Delete(string id)
        {
            try
            {
                IEnumerable<T> entities = _reader.Read();
                _reader.Save(
                    entities.Where(e => e.Id != id)
                );

                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _reader.Read();
        }

        public T GetById(string id)
        {
            return _reader.Read().TakeWhile(e => e.Id == id).First();
        }

        public bool Insert(T entity)
        {
            try
            {
                IEnumerable<T> entities = _reader.Read();
                _reader.Save([entity, .. entities]);

                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                IEnumerable<T> entities = _reader.Read();
                _reader.Save(
                    [entity, .. entities.Where(e => e.Id != entity.Id)]
                );

                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
    }
}
