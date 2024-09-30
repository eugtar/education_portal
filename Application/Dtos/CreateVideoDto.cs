using Domain.Enums;

namespace Application.Dtos;

public class CreateVideoDto(
    string title,
    TimeOnly duration,
    VideoQuality quality
    )
{
    public string Title => title;
    public TimeOnly Duration => duration;
    public VideoQuality Quality => quality;
}
