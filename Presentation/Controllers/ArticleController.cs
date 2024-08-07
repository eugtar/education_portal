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
            ConsoleAlert.Result(_ui.GetAll());
        }

        public void GetById()
        {
            ConsoleAlert.Result(_articleService.GetById(_ui.GetById()));
        }

        public void Update()
        {
            var id = _articleService.GetById(_ui.GetById()).Id;
            var article = _articleService.Update(id, _ui.Update());

            ConsoleAlert.Result(article);
        }
    }
}
