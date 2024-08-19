using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Video : BaseEntity
{
    public string Title { get; set; } = null!;
    public TimeOnly Duration { get; set; }
    public VideoQuality Quality { get; set; }
    public ICollection<Course> Courses { get; } = null!;
}