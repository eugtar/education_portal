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
            var newArticle = new Article(
                Guid.NewGuid().ToString(),
                createArticleDto.Title,
                createArticleDto.Link,
                DateTime.Now.TimeOfDay,
                DateTime.Now.TimeOfDay
            );

            return _repository.Insert(newArticle) ? newArticle : throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public List<Article> GetAll()
        {
            var articles = _repository.GetAll().ToList();
            
            return articles.Count == 0 ? throw new NotImplementedException() : articles;
        }

        public Article GetById(string id)
        {
            return _repository.GetById(id) ?? throw new NotImplementedException();
        }

        public Article Update(string id, UpdateArticleDto updateArticleDto)
        {
            var article = _repository.GetById(id) ?? throw new NotImplementedException();

            article.Title = updateArticleDto.Title ?? article.Title;
            article.Link = updateArticleDto.Link ?? article.Link;
            article.UpdatedAt = DateTime.Now.TimeOfDay;

            return _repository.Update(article) ? article : throw new NotImplementedException();
        }
    }
}
