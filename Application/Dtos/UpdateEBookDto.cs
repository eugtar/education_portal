using Domain.Enums;

namespace Application.Dtos;

public class UpdateEbookDto(
    string? title,
    string? author,
    int? pageAmount,
    EbookFormat? format,
    DateTime? publishedOn
    )
{
    public string? Title => title;
    public string? Author => author;
    public int? PageAmount => pageAmount;
    public EbookFormat? Format => format;
    public DateTime? PublishedOn => publishedOn;
}
