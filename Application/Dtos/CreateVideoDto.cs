using Domain.Enums;

namespace Application.Dtos;

public sealed class CreateVideoDto
{
    public required string Title { get; set; }
    public string Duration { get; set; } = new TimeSpan(0, 0, 0).ToString();
    public VideoQuality QualityId { get; set; } = VideoQuality._1080p;
}
