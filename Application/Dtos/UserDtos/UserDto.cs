using Application.Dtos.RoleDtos;
using Domain.Entities.UserGroup;

namespace Application.Dtos.UserDtos;

public sealed class UserDto
{
    public required int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required DateTime? CreatedAt { get; set; }
    public required DateTime? UpdatedAt { get; set; }
    public required IEnumerable<UserCourseDto> Courses { get; set; }
    public required IEnumerable<UserSkillDto> Skills { get; set; }
    public required IEnumerable<RoleDto> Roles { get; set; }

    public static UserDto MapToView(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName ?? "",
            LastName = user.LastName ?? "",
            Email = user.Email ?? "",
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
            Courses = user.UserCourses.Select(uc => UserCourseDto.MapToView(uc)),
            Skills = user.UserSkills.Select(us => UserSkillDto.MapToView(us)),
            Roles = user.UserRoles.Select(ur => RoleDto.MapToView(ur.Role))
        };
    }
}
