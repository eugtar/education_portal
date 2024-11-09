using Domain.Enums;

namespace Application.Dtos;

public sealed class UpdateEbookDto
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int? PageAmount { get; set; }
    public EbookFormat? FormatId { get; set; }
    public string? PublishedOn { get; set; }
}
