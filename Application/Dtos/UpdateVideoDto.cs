using Domain.Enums;

namespace Application.Dtos;

public class UpdateVideoDto(
    string? title = null,
    TimeOnly? duration = null,
    VideoQuality? qualityId = null
    )
{
    public string? Title => title;
    public TimeOnly? Duration => duration;
    public VideoQuality? QualityId => qualityId;
}
