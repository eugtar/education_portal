using Domain.Common;

namespace Domain.Entities;

public partial class User : BaseEntity
{
    public required string? FirstName { get; set; }
    public required string? LastName { get; set; }
    public required string Email { get; set; } = null!;
    public required string HashPassword { get; set; } = null!;
    public virtual ICollection<UserCourse> UserCourses { get; set; } = [];
    public virtual ICollection<UserSkill> UserSkills { get; set; } = [];
}
