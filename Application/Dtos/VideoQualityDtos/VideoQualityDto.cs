using Domain.Entities;

namespace Application.Dtos.VideoQualityDtos;

public sealed class VideoQualityDto
{
    public required int Id { get; set; }
    public required string Type { get; set; }
    public required DateTime? CreatedAt { get; set; }
    public required DateTime? UpdatedAt { get; set; }

    public static VideoQualityDto MapToView(Quality q)
    {
        return new VideoQualityDto
        {
            Id = q.Id,
            Type = q.QualityType,
            CreatedAt = q.CreatedAt,
            UpdatedAt = q.UpdatedAt
        };
    }
}
