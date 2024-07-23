using Domain;

namespace Application
{
    public class EBookService : IEBookService
    {
        private readonly IEBookRepository _eBookRepo;

        public EBookService() : this(new EBookRepository()) { }

        public EBookService(IEBookRepository eBookRepository) 
        {
            _eBookRepo = eBookRepository;
        }

        public EBook Create(CreateEBookDto createEBookDto)
        {
            return _eBookRepo.Create(createEBookDto);
        }

        public void Delete(string id)
        {
            _eBookRepo.Delete(id);
        }

        public List<EBook?> GetAll()
        {
            return _eBookRepo.GetAll();
        }

        public EBook? GetUnique(string id)
        {
            throw new NotImplementedException();
        }

        public EBook Update(string id, UpdateEBookDto updateEBookDto)
        {
            throw new NotImplementedException();
        }
    }
}
