using Domain.Common;

namespace Domain.Entities;

public partial class Format : BaseEntity
{
    public required string FormatType { get; set; } = null!;
    public virtual ICollection<Ebook> Ebooks { get; set; } = [];
}
