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
            string title = ReadText("Article title");
            Uri link = new Uri(ReadText("Link to article"));

            return new CreateArticleDto(title, link);
        }


        public string Delete()
        {
            List<Article?> articles = _service.GetAll();

            if (articles.Count == 0)
            {
                Console.WriteLine("Not Found");
                App.StopProcess();
            }

            return articles[SelectOne<Article>(articles)]?.Id;
        }


        public string SelectOne()
        {
            throw new NotImplementedException();
        }


        public UpdateArticleDto Update()
        {
            throw new NotImplementedException();
        }
    }
}
