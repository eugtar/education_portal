namespace Application.Dtos;

public class UpdateCourseDto(
    string? title = null,
    string? description = null
    )
{
    public string? Title => title;
    public string? Description => description;
}