namespace Domain.Entities;

public partial class Skill
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RewardId { get; set; }
    public int Level { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual Reward Reward { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
