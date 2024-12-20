using Domain.Enums;

namespace Application.Dtos.VideoDtos;

public sealed class CreateVideoDto
{
    private string _title = null!;
    private string _duration = null!;
    private VideoQualityEnum _qualityId = VideoQualityEnum._720p;
    public required string Title
    {
        get => _title;
        set => _title = value.Trim().ToLower();
    }
    public required string Duration
    {
        get => _duration;
        set => _duration = value.Trim().ToLower();
    }
    public required VideoQualityEnum QualityId
    {
        get => _qualityId;
        set => _qualityId = value;
    }
}
