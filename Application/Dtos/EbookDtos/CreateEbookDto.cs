using Domain.Enums;

namespace Application.Dtos.EbookDtos;

public sealed class CreateEbookDto
{
    private string _title = null!;
    private string _author = null!;
    private int _pageAmount = default;
    private EbookFormatEnum _formatId = EbookFormatEnum.PDF;
    private string _publishedOn = null!;
    public required string Title
    {
        get => _title;
        set => _title = value.Trim().ToLower();
    }
    public required string Author
    {
        get => _author;
        set => _author = value.Trim().ToLower();
    }
    public required int PageAmount
    {
        get => _pageAmount;
        set => _pageAmount = value;
    }
    public required EbookFormatEnum FormatId
    {
        get => _formatId;
        set => _formatId = value;
    }
    public required string PublishedOn
    {
        get => _publishedOn;
        set => _publishedOn = value.Trim().ToLower();
    }
}
