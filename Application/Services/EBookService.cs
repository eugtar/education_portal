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
            var newEBook = new EBook(
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
            var eBooks = _repository.GetAll().ToList();

            return eBooks.Count == 0 ? throw new NotImplementedException() : eBooks;
        }

        public EBook GetById(string id)
        {
            return _repository.GetById(id) ?? throw new NotImplementedException();
        }

        public EBook Update(string id, UpdateEBookDto updateEBookDto)
        {
            var eBook = _repository.GetById(id) ?? throw new NotImplementedException();

            eBook.Title = updateEBookDto.Title ?? eBook.Title;
            eBook.Author = updateEBookDto.Author ?? eBook.Author;
            eBook.PageAmount = updateEBookDto.PageAmount ?? eBook.PageAmount;
            eBook.Format = updateEBookDto.Format ?? eBook.Format;
            eBook.PublishedOn = updateEBookDto.PublishedOn ?? eBook.PublishedOn;
            eBook.UpdatedAt = DateTime.Now.TimeOfDay;

            return _repository.Update(eBook) ? eBook : throw new NotImplementedException();
        }
    }
}
