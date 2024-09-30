using Application.Dtos;

namespace Presentation.Uis.Interfaces;
public interface ILessonUi
{
    public CreateLessonDto Create();
    public UpdateLessonDto Update();
    public int Delete();
    public int GetById();
    public string GetAll();
}
