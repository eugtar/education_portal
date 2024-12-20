using Application.Services.Interfaces;
using Domain.Entities.UserGroup;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

public class RoleService : IRoleService
{
    private string[] _roles = ["guest", "student", "teacher", "administrator"];
    private readonly UserManager<User> _userManager;

    public RoleService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task SetAsAdministratorAsync(User user) => await SetRoleAsync(user, UserRoleEnum.Admin);

    public async Task SetAsTeacherAsync(User user) => await SetRoleAsync(user, UserRoleEnum.Teacher);

    public async Task SetAsStudentAsync(User user) => await SetRoleAsync(user, UserRoleEnum.Student);

    private async Task SetRoleAsync(User user, UserRoleEnum userRole)
    {
        var role = (int)userRole switch
        {
            1 => _roles,
            2 => new ArraySegment<string>(_roles, 0, 3),
            3 => new ArraySegment<string>(_roles, 0, 2),
            _ => new ArraySegment<string>(_roles, 0, 1)
        };

        await _userManager.RemoveFromRolesAsync(user, _roles);
        await _userManager.AddToRolesAsync(user, role);
    }
}
