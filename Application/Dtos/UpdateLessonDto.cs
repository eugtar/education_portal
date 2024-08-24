namespace Application.Dtos;

public class UpdateLessonDto(string? title, string? description)
{
    public string? Title => title;
    public string? Description => description;
}