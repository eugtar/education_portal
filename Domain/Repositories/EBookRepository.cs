

namespace Domain
{
    public class EBookRepository : Repository<EBook>, IEBookRepository
    {
        public EBookRepository() : this("ebooks") { }

        public EBookRepository(string name) : base(name) { }

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


            List<EBook> eBooks = Read();
            Write([newEBook, .. eBooks]);

            return newEBook;
        }

        public void Delete(string id)
        {
            List<EBook> eBooks = Read();
            if (eBooks.Count == 0)
            {
                return;
            }

            int i = eBooks.FindIndex(eBook => eBook?.Id == id);

            if (i == -1)
            {
                new NotImplementedException();
            }

            eBooks.RemoveAt(i);
            Write(eBooks);

            return;
        }

        public List<EBook> GetAll()
        {
            return Read();
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