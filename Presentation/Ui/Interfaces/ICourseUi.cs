using Application;

namespace Presentation
{
    public interface ICourseUi
    {
        CreateCourseDto Create();
        UpdateCourseDto Update();
        string Delete();
        string GetById();
        string GetAll();
    }
}
