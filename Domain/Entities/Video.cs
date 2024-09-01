using Domain.Common;

namespace Domain.Entities;

public partial class Video : BaseEntity
{
    public required string Title { get; set; } = null!;
    public required TimeOnly Duration { get; set; }
    public required int Quality { get; set; }
    public virtual Quality QualityNavigation { get; set; } = null!;
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
