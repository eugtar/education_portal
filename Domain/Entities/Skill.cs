using Domain.Common;

namespace Domain.Entities;

public partial class Skill : BaseEntity
{
    public required int UserId { get; set; }
    public required int RewardId { get; set; }
    public int Level { get; set; }
    public virtual Reward Reward { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
