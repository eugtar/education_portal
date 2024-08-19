using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

public class UserCourse : BaseEntity
{
    public int UserId { get; set; }
    public int CourseId { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public decimal Progress { get; set; } = decimal.Zero;
    public bool Finished { get; set; } = false;
    public User User { get; set; } = null!;
    public Course Course { get; set; } = null!;
}