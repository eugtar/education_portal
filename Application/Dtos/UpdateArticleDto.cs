namespace Application.Dtos;

public class UpdateArticleDto(string? title, string? link)
{
    public string? Title => title;
    public string? Link => link;
}
