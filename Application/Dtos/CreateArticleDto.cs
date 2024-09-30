namespace Application.Dtos;

public class CreateArticleDto(string title, string link)
{
    public string Title => title;
    public string Link => link;
}
