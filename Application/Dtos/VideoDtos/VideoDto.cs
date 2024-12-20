using Application.Dtos.VideoQualityDtos;
using Domain.Entities;

namespace Application.Dtos.VideoDtos;

public sealed class VideoDto
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required TimeOnly Duration { get; set; }
    public required VideoQualityDto Quality { get; set; }
    public required DateTime? CreatedAt { get; set; }
    public required DateTime? UpdatedAt { get; set; }

    public static VideoDto MapToView(Video v)
    {
        return new VideoDto
        {
            Id = v.Id,
            Title = v.Title,
            Duration = v.Duration,
            Quality = VideoQualityDto.MapToView(v.Quality),
            CreatedAt = v.CreatedAt,
            UpdatedAt = v.UpdatedAt
        };
    }
}
