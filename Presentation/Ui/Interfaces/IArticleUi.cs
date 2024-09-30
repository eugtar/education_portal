using Application;

namespace Presentation
{
    public interface IArticleUi
    {
        CreateArticleDto Create();
        UpdateArticleDto Update();
        string Delete();
        string GetById();
        string GetAll();
    }
}
