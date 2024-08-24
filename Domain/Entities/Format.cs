namespace Domain.Entities;

public partial class Format
{
    public int Id { get; set; }
    public string Format1 { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual ICollection<Ebook> Ebooks { get; set; } = new List<Ebook>();
}
