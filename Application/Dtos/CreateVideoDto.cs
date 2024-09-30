using Domain.Enums;

namespace Application.Dtos;

public class CreateVideoDto(
    string title,
    TimeOnly duration,
    VideoQuality qualityId
    )
{
    public string Title => title;
    public TimeOnly Duration => duration;
    public VideoQuality QualityId => qualityId;
}
