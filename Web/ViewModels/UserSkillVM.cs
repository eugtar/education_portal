using Web.ViewModels.Common;

namespace Web.ViewModels;

public class UserSkillVM : BaseVM
{
    public required int UserId { get; set; }
    public required int SkillId { get; set; }
    public int Level { get; set; }
}
