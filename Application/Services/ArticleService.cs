using Domain;

namespace Application
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepo;

        public ArticleService() : this(new ArticleRepository()) { }

        public ArticleService(IArticleRepository articleRepository) 
        {
            _articleRepo = articleRepository;
        }

        public Article Create(CreateArticleDto createArticleDto)
        {
            return _articleRepo.Create(createArticleDto);
        }

        public void Delete(string id)
        {
            _articleRepo.Delete(id);
        }

        public List<Article?> GetAll()
        {
            return _articleRepo.GetAll();
        }

        public Article? GetUnique(string id)
        {
            throw new NotImplementedException();
        }

        public Article? Update(string id, UpdateArticleDto updateArticleDto)
        {
            throw new NotImplementedException();
        }
    }
}
