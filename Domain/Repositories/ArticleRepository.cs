
namespace Domain
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository() : this("articles") { }

        public ArticleRepository(string name) : base(name) { }

        public Article Create(CreateArticleDto createArticleDto)
        {
            Article newArticle = new(
                Guid.NewGuid().ToString(),
                createArticleDto.Title,
                createArticleDto.Link,
                DateTime.Now.TimeOfDay,
                DateTime.Now.TimeOfDay
            );


            List<Article> articles = Read();
            Write([newArticle, .. articles]);

            return newArticle;
        }

        public void Delete(string id)
        {
            List<Article> articles = Read();
            if (articles.Count == 0)
            {
                return;
            }

            int i = articles.FindIndex(article => article?.Id == id);

            if (i == -1)
            {
                new NotImplementedException();
            }

            articles.RemoveAt(i);
            Write(articles);

            return;
        }

        public List<Article> GetAll()
        {
            return Read();
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