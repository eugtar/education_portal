using Domain.Common;

namespace Domain.Entities;

public partial class Quality : BaseEntity
{
    public required string QualityType { get; set; } = null!;
    public virtual ICollection<Video> Videos { get; set; } = [];
}
