namespace Application.Dtos;

public class CreateCourseDto(string title, string description)
{
    public string Title => title;
    public string Description => description;
}
