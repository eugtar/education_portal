using Domain.Enums;

namespace Application.Dtos.EbookDtos;

public sealed class UpdateEbookDto
{
    private string? _title;
    private string? _author;
    private int? _pageAmount;
    private EbookFormatEnum? _formatId;
    private string? _publishedOn;
    public required string? Title
    {
        get => _title;
        set => _title = value?.Trim().ToLower();
    }
    public required string? Author
    {
        get => _author;
        set => _author = value?.Trim().ToLower();
    }
    public required int? PageAmount
    {
        get => _pageAmount;
        set => _pageAmount = value;
    }
    public required EbookFormatEnum? FormatId
    {
        get => _formatId;
        set => _formatId = value;
    }
    public required string? PublishedOn
    {
        get => _publishedOn;
        set => _publishedOn = value;
    }
}
