using Web.ViewModels.Common;

namespace Web.ViewModels;

public class UserCourseVM : BaseVM
{
    public required int UserId { get; set; }
    public required int CourseId { get; set; }
    public bool Finished { get; set; }
    public decimal Progress { get; set; }
}
