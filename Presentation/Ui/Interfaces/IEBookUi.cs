using Application;

namespace Presentation
{
    public interface IEBookUi
    {
        CreateEBookDto Create();
        UpdateEBookDto Update();
        string Delete();
        string GetById();
        string GetAll();
    }
}
