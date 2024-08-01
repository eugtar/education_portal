using Domain;
using Infrastructure;

namespace Application
{
    public class ArticleService : IArticleService
    {
        private readonly IGenericRepository<Article> _repository;

        public ArticleService() : this(new GenericRepository<Article>("article")) { }

        public ArticleService(IGenericRepository<Article> articleRepository)
        {
            _repository = articleRepository;
        }

        public Article Create(CreateArticleDto createArticleDto)
        {
            return _repository.Create(createArticleDto);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public List<Article> GetAll()
        {
            return _repository.GetAll();
        }

        public Article GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Article Update(string id, UpdateArticleDto updateArticleDto)
        {
            throw new NotImplementedException();
        }
    }
}
