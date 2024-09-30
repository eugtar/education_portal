using Domain.Entities;

namespace Domain.Common;

public class Material : BaseEntity
{
    public string Type {get; set;} = null!;
    public required string Title { get; set; } = null!;
    public virtual ICollection<Course> Courses { get; set; } = [];

}
