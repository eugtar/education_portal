using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public partial class User : IdentityUser<int>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public new string Email { get; set; } = null!;
    // public int RoleId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    // public virtual Role Role { get; set; } = null!;
    public virtual IEnumerable<UserCourse> UserCourses { get; set; } = null!;
    public virtual IEnumerable<UserSkill> UserSkills { get; set; } = null!;
}
