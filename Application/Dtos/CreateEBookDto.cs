using Domain.Enums;

namespace Application.Dtos;

public sealed class CreateEbookDto
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public int PageAmount { get; set; } = 0;
    public EbookFormat FormatId { get; set; } = EbookFormat.PDF;
    public string PublishedOn { get; set; } = DateTime.UtcNow.ToString();
}
