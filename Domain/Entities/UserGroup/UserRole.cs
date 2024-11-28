using Domain.Entities.RoleGroup;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.UserGroup;

public partial class UserRole : IdentityUserRole<int>
{
    public virtual User User { get; set; } = null!;
    public virtual Role Role { get; set; } = null!;
}
