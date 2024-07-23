using Application;
using Domain;

namespace Presentation
{
    public class ArticleController : IController
    {
        IArticleUi _ui;
        IArticleService _articleService;

        public ArticleController() : this(new ArticleUi(), new ArticleService()) { }

        public ArticleController(IArticleUi ui, IArticleService articleService)
        {
            _ui = ui;
            _articleService = articleService;
        }

        public void Create()
        {
            Article newArticle = _articleService.Create(_ui.Create());

            Console.WriteLine(newArticle);
        }

        public void Delete()
        {
            _articleService.Delete(_ui.Delete());
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetUnique()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
