using Domain.Common;

namespace Domain.Entities;

public partial class Course : BaseEntity
{

    public required int UserId { get; set; }
    public required int LessonId { get; set; }
    public bool Finished { get; set; }
    public decimal Progress { get; set; }
    public virtual Lesson Lesson { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
