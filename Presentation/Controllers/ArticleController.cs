using Application;
using Domain;

namespace Presentation
{
    public class ArticleController : IController
    {
        private readonly IArticleService _articleService;
        private readonly IArticleUi _ui;

        public ArticleController() : this(new ArticleService()) { }

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
            _ui = new ArticleUi(_articleService);
        }

        public void Create()
        {
            var newArticle = _articleService.Create(_ui.Create());

            ConsoleAlert.Result(newArticle);
        }

        public void Delete()
        {
            _articleService.Delete(_ui.Delete());
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetById()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
