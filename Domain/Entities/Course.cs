using Domain.Common;
using Domain.Entities.UserGroup;

namespace Domain.Entities;

public partial class Course : BaseEntity
{
    public required string Title { get; set; } = null!;
    public required string Description { get; set; } = null!;
    public virtual ICollection<UserCourse> UserCourses { get; set; } = null!;
    public virtual ICollection<Material> Materials { get; set; } = null!;
    public virtual ICollection<Skill> Skills { get; set; } = null!;
}
