namespace Application.Dtos.ArticleDtos;

public sealed class UpdateArticleDto
{
    private string? _title;
    private string? _link;
    public required string? Title
    {
        get => _title;
        set => _title = value?.Trim().ToLower();
    }
    public required string? Link
    {
        get => _link;
        set => _link = value?.Trim().ToLower();
    }
}
