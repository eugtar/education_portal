using System.ComponentModel;

namespace Domain {
    public enum VideoQuality
    {
        [Description("360p")]
        LOW = 0,
        [Description("480p")]
        MEDIUM = 1,
        [Description("720p")]
        HIGH = 2,
        [Description("1080p")]
        ULTRAHIGH = 3
    }
}