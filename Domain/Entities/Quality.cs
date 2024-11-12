using Domain.Common;

namespace Domain.Entities;

public partial class Quality : BaseEntity
{
    public required string QualityType { get; set; } = null!;
    public virtual IEnumerable<Video> Videos { get; set; } = null!;
}
