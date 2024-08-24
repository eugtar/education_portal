namespace Domain.Entities;

public partial class Quality
{
    public int Id { get; set; }
    public string Quality1 { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual ICollection<Video> Videos { get; set; } = new List<Video>();
}
