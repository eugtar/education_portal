using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.UserGroup;

public partial class UserToken : IdentityUserToken<int>
{
    public virtual User User { get; set; } = null!;
}
