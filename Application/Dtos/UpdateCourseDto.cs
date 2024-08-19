namespace Application.Dtos;

public class UpdateCourseDto(string? title, string? description)
{
    public string? Title => title;
    public string? Description => description;
}