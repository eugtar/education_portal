using Domain.Entities.UserGroup;
using Domain.Enums;

namespace Application.Dtos.RoleDtos;

public sealed class SetRoleDto
{
    private User _user = null!;
    private UserRoleEnum _role = UserRoleEnum.Guest;
    public required User User
    {
        get => _user;
        set => _user = value;
    }
    public required UserRoleEnum Role
    {
        get => _role;
        set => _role = value;
    }
}
