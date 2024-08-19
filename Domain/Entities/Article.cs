using Domain.Common;

namespace Domain.Entities;

public class Article : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Link { get; set; } = null!;
    public ICollection<Course> Courses { get; } = null!;
}