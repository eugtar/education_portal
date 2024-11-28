using Domain.Entities.UserGroup;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.RoleGroup;

public partial class Role : IdentityRole<int>
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public virtual IEnumerable<UserRole> UserRoles { get; set; } = null!;
    public virtual IEnumerable<RoleClaim> RoleClaims { get; set; } = null!;
}
