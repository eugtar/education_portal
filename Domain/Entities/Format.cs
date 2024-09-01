using Domain.Common;

namespace Domain.Entities;

public partial class Format : BaseEntity
{
    public string Format1 { get; set; } = null!;
    public virtual ICollection<Ebook> Ebooks { get; set; } = new List<Ebook>();
}
