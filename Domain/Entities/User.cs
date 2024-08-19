using Domain.Common;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public ICollection<UserCourse> UserCourses { get; } = null!;
    public ICollection<UserSkill> UserSkills { get; } = null!;
}