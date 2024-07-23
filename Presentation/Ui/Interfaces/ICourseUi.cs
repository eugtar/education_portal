using Domain;

namespace Presentation
{
    public interface ICourseUi
    {
        CreateCourseDto Create();
        UpdateCourseDto Update();
        string SelectOne();
        string Delete();
    }
}
