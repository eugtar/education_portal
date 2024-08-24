using Domain.Enums;

namespace Application.Dtos;

public class UpdateVideoDto(
    string? title,
    TimeOnly? duration,
    VideoQuality? quality
    )
{
    public string? Title => title;
    public TimeOnly? Duration => duration;
    public VideoQuality? Quality => quality;
}
