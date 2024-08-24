namespace Domain.Entities;

public partial class Lesson
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
    public virtual ICollection<Ebook> Ebooks { get; set; } = new List<Ebook>();
    public virtual ICollection<Reward> Rewards { get; set; } = new List<Reward>();
    public virtual ICollection<Video> Videos { get; set; } = new List<Video>();
}
