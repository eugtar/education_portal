using System.ComponentModel;

namespace Domain {
    public enum VideoQuality
    {
        [Description("360p")]
        LOW,
        [Description("480p")]
        MEDIUM,
        [Description("720p")]
        HIGH,
        [Description("1080p")]
        ULTRAHIGH
    }
}