using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class EBook : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public int PageAmount { get; set; }
    public EBookFormat Format { get; set; }
    public DateTime PublishedOn { get; set; }
    public ICollection<Course> Courses { get; } = null!;
}