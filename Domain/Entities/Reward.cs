namespace Domain.Entities;

public partial class Reward
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
