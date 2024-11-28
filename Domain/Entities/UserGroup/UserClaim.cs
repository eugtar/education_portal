using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.UserGroup;

public partial class UserClaim : IdentityUserClaim<int>
{
    public virtual User User { get; set; } = null!;
}
