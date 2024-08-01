namespace Domain
{
    public interface IArticleRepository
    {
        public Article Create(CreateArticleDto createArticleDto);
        public Article Update(string id, UpdateArticleDto updateArticleDto);
        public void Delete(string id);
        public Article GetById(string id);
        public List<Article> GetAll();
    }
}
