using Domain.Common;

namespace Domain.Entities;

public partial class Skill : BaseEntity
{
    public required string Name { get; set; } = null!;
    public virtual ICollection<UserSkill> UserSkills { get; set; } = [];
    public virtual ICollection<Course> Courses { get; set; } = [];
}
