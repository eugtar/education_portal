using Domain.Enums;

namespace Application.Dtos;

public sealed class UpdateVideoDto
{
    public string? Title { get; set; }
    public string? Duration { get; set; }
    public VideoQuality? QualityId { get; set; }
}
