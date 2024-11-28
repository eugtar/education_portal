using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.RoleGroup;

public partial class RoleClaim : IdentityRoleClaim<int>
{
    public virtual Role Role { get; set; } = null!;
}
