using Application.Dtos;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Presentation.Uis.Common;
using Presentation.Uis.Interfaces;

namespace Presentation.Uis;

public class VideoUi : Ui, IVideoUi
{
    private readonly IVideoService _service;

    public VideoUi(IVideoService videoService)
    {
        _service = videoService;
    }

    public CreateVideoDto Create()
    {
        var title = ReadText("Video title");
        var duration = new TimeOnly(
            ReadNumber("Hour(hh)"),
            ReadNumber("Minute(mm)")
        );

        List<string> videoQuality = ["low", "medium", "high", "ultrahigh"];
        var quality = SelectOne(videoQuality) switch
        {
            0 => VideoQuality.LOW,
            1 => VideoQuality.MEDIUM,
            2 => VideoQuality.HIGH,
            _ => VideoQuality.LOW,
        };

        return new CreateVideoDto(title, duration, quality);
    }

    public int Delete()
    {
        var videos = _service.GetAll();

        return videos[SelectOne<Video>(videos)].Id;
    }

    public string GetAll()
    {
        return $"[{string.Join(",\n", _service.GetAll())}]";
    }

    public int GetById()
    {
        var videos = _service.GetAll();

        return videos[SelectOne<Video>(videos)].Id;
    }

    public UpdateVideoDto Update()
    {
        var title = ReadText("Video title", false);
        var duration = new TimeOnly(
            ReadNumber("Hour(hh)"),
            ReadNumber("Minute(mm)")
        );

        List<string> videoQuality = ["low", "medium", "high", "ultrahigh"];
        var quality = SelectOne(videoQuality) switch
        {
            0 => VideoQuality.LOW,
            1 => VideoQuality.MEDIUM,
            2 => VideoQuality.HIGH,
            _ => VideoQuality.LOW,
        };

        return new UpdateVideoDto(title, duration, quality);
    }
}
