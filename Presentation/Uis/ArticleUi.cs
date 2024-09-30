using Application.Dtos;
using Application.Services.Interfaces;
using Domain.Entities;
using Presentation.Uis.Common;
using Presentation.Uis.Interfaces;

namespace Presentation.Uis
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
            var link = ReadText("Link to article");

            return new CreateArticleDto(title, link);
        }

        public int Delete()
        {
            var articles = _service.GetAll();

            return articles[SelectOne<Article>(articles)].Id;
        }

        public string GetAll()
        {
            return $"[{string.Join(",\n", _service.GetAll())}]";
        }

        public int GetById()
        {
            var articles = _service.GetAll();

            return articles[SelectOne<Article>(articles)].Id;
        }

        public UpdateArticleDto Update()
        {
            var title = ReadText("Article title", false);
            var link = ReadText("Link to article", false);

            return new UpdateArticleDto(title, link);
        }
    }
}
