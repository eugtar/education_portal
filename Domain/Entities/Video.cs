namespace Domain.Entities;

public partial class Video
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public TimeOnly Duration { get; set; }
    public int Quality { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual Quality QualityNavigation { get; set; } = null!;
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
