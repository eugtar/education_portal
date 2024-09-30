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

        List<string> videoQuality = ["144p", "240p", "360p", "480p", "720p", "1080p", "1440p", "2160p"];
        var quality = SelectOne(videoQuality) switch
        {
            0 => VideoQuality._144p,
            1 => VideoQuality._240p,
            2 => VideoQuality._360p,
            3 => VideoQuality._480p,
            4 => VideoQuality._720p,
            5 => VideoQuality._1080p,
            6 => VideoQuality._1440p,
            _ => VideoQuality._2160p,
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

        List<string> videoQuality = ["144p", "240p", "360p", "480p", "720p", "1080p", "1440p", "2160p"];
        var quality = SelectOne(videoQuality) switch
        {
            0 => VideoQuality._144p,
            1 => VideoQuality._240p,
            2 => VideoQuality._360p,
            3 => VideoQuality._480p,
            4 => VideoQuality._720p,
            5 => VideoQuality._1080p,
            6 => VideoQuality._1440p,
            _ => VideoQuality._2160p,
        };

        return new UpdateVideoDto(title, duration, quality);
    }
}
