using Domain.Enums;

namespace Application.Dtos.VideoDtos;

public sealed class UpdateVideoDto
{
    private string? _title;
    private string? _duration;
    private VideoQualityEnum? _qualityId;
    public required string? Title
    {
        get => _title;
        set => _title = value?.Trim().ToLower();
    }
    public required string? Duration
    {
        get => _duration;
        set => _duration = value?.Trim().ToLower();
    }
    public required VideoQualityEnum? QualityId
    {
        get => _qualityId;
        set => _qualityId = value;
    }
}
