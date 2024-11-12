namespace Application.Dtos;

public sealed class CreateArticleDto
{
    public required string Title { get; set; }
    public required string Link { get; set; }
}
