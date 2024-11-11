using Web.ViewModels.Common;

namespace Web.ViewModels;

public class UserVM : BaseVM
{
    public required string? FirstName { get; set; }
    public required string? LastName { get; set; }
    public required string Email { get; set; } = null!;
}
