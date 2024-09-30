using System.ComponentModel;

namespace Domain.Enums;

public enum VideoQuality
{
    [Description("Low")]
    LOW = 0,
    [Description("Medium")]
    MEDIUM = 1,
    [Description("High")]
    HIGH = 2,
    [Description("Ultra High")]
    ULTRAHIGH = 3
}
