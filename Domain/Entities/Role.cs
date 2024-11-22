using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public partial class Role : IdentityRole<int>
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    // public virtual IEnumerable<User> Users { get; set; } = null!;
}
