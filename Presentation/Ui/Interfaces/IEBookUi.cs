using Application;

namespace Presentation
{
    public interface IEBookUi
    {
        CreateEBookDto Create();
        UpdateEBookDto Update();
        string SelectOne();
        string Delete();
    }
}
