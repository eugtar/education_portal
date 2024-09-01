using Domain.Common;

namespace Domain.Entities;

public partial class Ebook : BaseEntity
{
    public required string Title { get; set; } = null!;
    public required string Author { get; set; } = null!;
    public required int PageAmount { get; set; }
    public required DateTime PublishedOn { get; set; }
    public required int Format { get; set; }
    public virtual Format FormatNavigation { get; set; } = null!;
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
