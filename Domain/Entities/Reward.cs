using Domain.Common;

namespace Domain.Entities;

public partial class Reward : BaseEntity
{
    public required string Name { get; set; } = null!;
    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
