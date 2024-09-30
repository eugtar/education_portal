using Domain.Common;

namespace Domain.Entities;

public partial class User : BaseEntity
{
    public required string? FirstName { get; set; }
    public required string? LastName { get; set; }
    public required string Email { get; set; } = null!;
    public required string HashPassword { get; set; } = null!;
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
