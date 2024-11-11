using Domain.Common;
using Domain.Entities;
using Web.ViewModels.Common;

namespace Web.ViewModels;

public class CourseVM : BaseVM
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ICollection<Material> Materials { get; set; } = null!;
    public ICollection<Skill> Skills {get; set;} = null!;
}
