using Domain.Entities;
using Web.ViewModels.Common;

namespace Web.ViewModels;

public class VideoVM : MaterialVM
{
    public required TimeOnly Duration { get; set; }
    public required int QualityId { get; set; }
    public virtual Quality Quality { get; set; } = null!;
}
