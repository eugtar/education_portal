using Domain.Entities;
using Web.ViewModels.Common;

namespace Web.ViewModels;

public class EbookVM : MaterialVM
{
    public required string Author { get; set; } = null!;
    public required int PageAmount { get; set; }
    public required DateTime PublishedOn { get; set; }
    public required int FormatId { get; set; }
    public virtual Format Format { get; set; } = null!;
}
