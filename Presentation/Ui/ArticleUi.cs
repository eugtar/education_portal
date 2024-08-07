using Application;
using Domain;

namespace Presentation
{
    public class ArticleUi : Ui, IArticleUi
    {
        private readonly IArticleService _service;

        public ArticleUi(IArticleService articleService)
        {
            _service = articleService;
        }

        public CreateArticleDto Create()
        {
            var title = ReadText("Article title");
            var link = new Uri(ReadText("Link to article"));

            return new CreateArticleDto(title, link);
        }

        public string Delete()
        {
            var articles = _service.GetAll();

            return articles[SelectOne<Article>(articles)].Id;
        }

        public string GetAll()
        {
            return $"[{string.Join(",\n", _service.GetAll())}]";
        }

        public string GetById()
        {
            var articles = _service.GetAll();

            return articles[SelectOne<Article>(articles)].Id;
        }

        public UpdateArticleDto Update()
        {
            var title = ReadText("Article title", false);
            var link = ReadText("Link to article", false);

            return new UpdateArticleDto(title, link is not null ? new Uri(link):null);
        }
    }
}
