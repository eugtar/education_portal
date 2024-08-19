using Domain.Common;

namespace Domain.Entities;

public class UserSkill : BaseEntity
{
    public int UserId { get; set; }
    public int SkillId { get; set; }
    public User User { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
    public int Level { get; set; } = 0;
}
