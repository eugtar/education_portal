using Domain;
using Infrastructure;

namespace Application
{
    public class EBookService : IEBookService
    {
        private readonly IGenericRepository<EBook> _repository;

        public EBookService() : this(new GenericRepository<EBook>("ebook")) { }

        public EBookService(IGenericRepository<EBook> eBookRepository)
        {
            _repository = eBookRepository;
        }

        public EBook Create(CreateEBookDto createEBookDto)
        {
            return _repository.Create(createEBookDto);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public List<EBook> GetAll()
        {
            return _repository.GetAll();
        }

        public EBook GetById(string id)
        {
            throw new NotImplementedException();
        }

        public EBook Update(string id, UpdateEBookDto updateEBookDto)
        {
            throw new NotImplementedException();
        }
    }
}
