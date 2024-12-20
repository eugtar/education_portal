using Application.Dtos.EbookFormatDtos;
using Domain.Entities;

namespace Application.Dtos.EbookDtos;

public sealed class EbookDto
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required int PageAmount { get; set; }
    public required DateTime PublishedOn { get; set; }
    public required EbookFormatDto Format { get; set; }
    public required DateTime? CreatedAt { get; set; }
    public required DateTime? UpdatedAt { get; set; }

    public static EbookDto MapToView(Ebook e)
    {
        return new EbookDto
        {
            Id = e.Id,
            Title = e.Title,
            Author = e.Author,
            PageAmount = e.PageAmount,
            PublishedOn = e.PublishedOn,
            Format = EbookFormatDto.MapToView(e.Format),
            CreatedAt = e.CreatedAt,
            UpdatedAt = e.UpdatedAt,
        };
    }
}
