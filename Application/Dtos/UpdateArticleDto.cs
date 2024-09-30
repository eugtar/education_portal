namespace Application.Dtos;

public class UpdateArticleDto(
    string? title = null,
    string? link = null
    )
{
    public string? Title => title;
    public string? Link => link;
}
