namespace Domain.Entities;

public partial class Course
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int LessonId { get; set; }
    public bool Finished { get; set; }
    public decimal Progress { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual Lesson Lesson { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
