using Domain.Common;

namespace Domain.Entities;

public class Course : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ICollection<EBook> EBooks { get; } = null!;
    public ICollection<Article> Articles { get; } = null!;
    public ICollection<Video> Videos { get; } = null!;
    public ICollection<Skill> Skills { get; } = null!;
    public ICollection<UserCourse> UserCourses { get; } = null!;
}