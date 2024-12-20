using Domain.Entities;

namespace Application.Dtos.ArticleDtos;

public sealed class ArticleDto
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Link { get; set; }
    public required DateTime? CreatedAt { get; set; }
    public required DateTime? UpdatedAt { get; set; }

    public static ArticleDto MapToView(Article a)
    {
        return new ArticleDto
        {
            Id = a.Id,
            Title = a.Title,
            Link = a.Link,
            CreatedAt = a.CreatedAt,
            UpdatedAt = a.UpdatedAt
        };
    }
}
