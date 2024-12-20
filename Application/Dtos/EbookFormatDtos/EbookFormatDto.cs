using Domain.Entities;

namespace Application.Dtos.EbookFormatDtos;

public sealed class EbookFormatDto
{
    public required int Id { get; set; }
    public required string Type { get; set; }
    public required DateTime? CreatedAt { get; set; }
    public required DateTime? UpdatedAt { get; set; }

    public static EbookFormatDto MapToView(Format f)
    {
        return new EbookFormatDto
        {
            Id = f.Id,
            Type = f.FormatType,
            CreatedAt = f.CreatedAt,
            UpdatedAt = f.UpdatedAt
        };
    }
}
