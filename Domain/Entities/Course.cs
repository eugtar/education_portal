using Domain.Common;

namespace Domain.Entities;

public partial class Course : BaseEntity
{
    public required string Title { get; set; } = null!;
    public required string Description { get; set; } = null!;
    public virtual IEnumerable<UserCourse> UserCourses { get; set; } = null!;
    public virtual IEnumerable<Material> Materials { get; set; } = null!;
    public virtual IEnumerable<Skill> Skills { get; set; } = null!;
}
