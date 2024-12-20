using Domain.Common;
using Domain.Entities.UserGroup;

namespace Domain.Entities;

public partial class Skill : BaseEntity
{
    public required string Name { get; set; } = null!;
    public virtual ICollection<UserSkill> UserSkills { get; set; } = null!;
    public virtual ICollection<Course> Courses { get; set; } = null!;
}
