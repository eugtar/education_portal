using Domain;

namespace Presentation
{
    public interface IVideoUi
    {
        CreateVideoDto Create();
        UpdateVideoDto Update();
        string SelectOne();
        string Delete();
    }
}
