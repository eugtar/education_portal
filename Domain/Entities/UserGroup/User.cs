using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.UserGroup;

public partial class User : IdentityUser<int>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public virtual ICollection<UserCourse> UserCourses { get; set; } = null!;
    public virtual ICollection<UserSkill> UserSkills { get; set; } = null!;
    public virtual ICollection<UserClaim> Claims { get; set; } = null!;
    public virtual ICollection<UserLogin> Logins { get; set; } = null!;
    public virtual ICollection<UserToken> Tokens { get; set; } = null!;
    public virtual ICollection<UserRole> UserRoles { get; set; } = null!;
}
