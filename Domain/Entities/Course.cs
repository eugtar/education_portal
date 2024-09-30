using Domain.Common;

namespace Domain.Entities;

public partial class Course : BaseEntity
{
    public required string Title { get; set; } = null!;
    public required string Description { get; set; } = null!;
    public virtual ICollection<UserCourse> UserCourses { get; set; } = [];
    // public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
    // public virtual ICollection<Ebook> Ebooks { get; set; } = new List<Ebook>();
    // public virtual ICollection<Video> Videos { get; set; } = new List<Video>();
    public virtual ICollection<Material> Materials { get; set; } = [];
    public virtual ICollection<Skill> Skills { get; set; } = [];
}
