using Domain;

namespace Application
{
    public interface IArticleService
    {
        public Article Create(CreateArticleDto createArticleDto);
        public Article? Update(string id, UpdateArticleDto updateArticleDto);
        public void Delete(string id);
        public Article? GetUnique(string id);
        public List<Article?> GetAll();
    }
}
