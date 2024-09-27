using Web.ViewModels.Common;

namespace Web.ViewModels;

public class CourseVM : BaseVM
{
    public required string Title { get; set; } = null!;
    public required string Description { get; set; } = null!;
}
