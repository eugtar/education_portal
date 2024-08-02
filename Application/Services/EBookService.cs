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
            EBook newEBook = new(
                Guid.NewGuid().ToString(),
                createEBookDto.Title,
                createEBookDto.Author,
                createEBookDto.PageAmount,
                createEBookDto.Format,
                createEBookDto.PublishedOn,
                DateTime.Now.TimeOfDay,
                DateTime.Now.TimeOfDay
            );

            return _repository.Insert(newEBook) ? newEBook : throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public List<EBook> GetAll()
        {
            return _repository.GetAll().ToList();
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
