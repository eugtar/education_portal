namespace Application.Dtos;

public class CreateLessonDto(string title, string description)
{
    public string Title => title;
    public string Description => description;
}
