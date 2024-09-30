using System.ComponentModel;

namespace Domain.Enums;

public enum VideoQuality
{
    [Description("144p")]
    _144p = 1,
    [Description("240p")]
    _240p = 2,
    [Description("360p")]
    _360p = 3,
    [Description("480p")]
    _480p = 4,
    [Description("720p")]
    _720p = 5,
    [Description("1080p")]
    _1080p = 6,
    [Description("1440p")]
    _1440p = 7,
    [Description("2160p")]
    _2160p = 8
}