using Domain.Common;

namespace Domain.Entities;

public class Skill : BaseEntity
{
    public string Name { get; set; } = null!;
    public ICollection<Course> Courses { get; } = null!;
    public ICollection<UserSkill> UserSkills { get; } = null!;
}