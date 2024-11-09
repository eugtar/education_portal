using Domain.Common;

namespace Domain.Entities;

public partial class Skill : BaseEntity
{
    public required string Name { get; set; } = null!;
    public virtual IEnumerable<UserSkill> UserSkills { get; set; } = null!;
    public virtual IEnumerable<Course> Courses { get; set; } = null!;
}
