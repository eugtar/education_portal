using Domain.Common;

namespace Domain.Entities;

public partial class Ebook : Material
{
    public required string Author { get; set; } = null!;
    public required int PageAmount { get; set; }
    public required DateTime PublishedOn { get; set; }
    public required int FormatId { get; set; }
    public virtual Format Format { get; set; } = null!;
    // public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
