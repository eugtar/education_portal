using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.UserGroup;

public partial class UserLogin : IdentityUserLogin<int>
{
    public virtual User User { get; set; } = null!;
}
