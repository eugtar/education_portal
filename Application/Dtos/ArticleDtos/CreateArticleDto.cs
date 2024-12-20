namespace Application.Dtos.ArticleDtos;

public sealed class CreateArticleDto
{
    private string _title = null!;
    private string _link = null!;
    public required string Title
    {
        get => _title;
        set => _title = value.Trim().ToLower();
    }
    public required string Link
    {
        get => _link;
        set => _link = value.Trim();
    }
}
