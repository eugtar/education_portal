using Domain.Common;

namespace Domain.Entities;

public partial class Video : Material
{
    public required TimeOnly Duration { get; set; }
    public required int QualityId { get; set; }
    public virtual Quality Quality { get; set; } = null!;
    // public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
