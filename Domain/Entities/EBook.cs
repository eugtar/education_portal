namespace Domain.Entities;

public partial class Ebook
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public int PageAmount { get; set; }
    public DateTime PublishedOn { get; set; }
    public int Format { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual Format FormatNavigation { get; set; } = null!;
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
