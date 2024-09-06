using Application.Dtos;

namespace Presentation.Uis.Interfaces;
public interface ICourseUi
{
    public CreateCourseDto Create();
    public UpdateCourseDto Update();
    public int Delete();
    public int GetById();
    public string GetAll();
}
