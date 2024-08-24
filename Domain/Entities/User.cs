namespace Domain.Entities;

public partial class User
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; } = null!;
    public string HashPassword { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
