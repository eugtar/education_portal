using Application;

namespace Presentation
{
    public interface IVideoUi
    {
        CreateVideoDto Create();
        UpdateVideoDto Update();
        string Delete();
        string GetById();
        string GetAll();
    }
}
