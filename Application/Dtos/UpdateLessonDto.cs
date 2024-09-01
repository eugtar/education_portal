namespace Application.Dtos;

public class UpdateLessonDto(
    string? title = null,
    string? description = null
    )
{
    public string? Title => title;
    public string? Description => description;
}