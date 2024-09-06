using Domain.Enums;

namespace Application.Dtos;

public class CreateEbookDto(
    string title,
    string author,
    int pageAmount,
    EbookFormat formatId,
    DateTime publishedOn
    )
{
    public string Title => title;
    public string Author => author;
    public int PageAmount => pageAmount;
    public EbookFormat FormatId => formatId;
    public DateTime PublishedOn => publishedOn;
}
