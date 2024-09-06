using Domain.Enums;

namespace Application.Dtos;

public class UpdateEbookDto(
    string? title = null,
    string? author = null,
    int? pageAmount = null,
    EbookFormat? formatId = null,
    DateTime? publishedOn = null
    )
{
    public string? Title => title;
    public string? Author => author;
    public int? PageAmount => pageAmount;
    public EbookFormat? FormatId => formatId;
    public DateTime? PublishedOn => publishedOn;
}
