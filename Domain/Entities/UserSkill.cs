using Domain.Common;

namespace Domain.Entities;

public partial class UserSkill : BaseEntity
{
    public required int UserId { get; set; }
    public required int SkillId { get; set; }
    public int Level { get; set; }
    public virtual Skill Skill { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
