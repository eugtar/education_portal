using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.UserGroup;

public partial class User : IdentityUser<int>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public virtual IEnumerable<UserCourse> UserCourses { get; set; } = null!;
    public virtual IEnumerable<UserSkill> UserSkills { get; set; } = null!;
    public virtual IEnumerable<UserClaim> Claims { get; set; } = null!;
    public virtual IEnumerable<UserLogin> Logins { get; set; } = null!;
    public virtual IEnumerable<UserToken> Tokens { get; set; } = null!;
    public virtual IEnumerable<UserRole> UserRoles { get; set; } = null!;
}
