using Domain.Common;

namespace Domain.Entities;

public partial class UserCourse : BaseEntity
{

    public required int UserId { get; set; }
    public required int CourseId { get; set; }
    public bool Finished { get; set; }
    public decimal Progress { get; set; }
    public virtual Course Course { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
