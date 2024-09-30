using Domain.Common;

namespace Domain.Entities;

public partial class Article : BaseEntity
{
    public required string Title { get; set; } = null!;
    public required string Link { get; set; } = null!;
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
