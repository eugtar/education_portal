using Domain.Common;

namespace Domain.Entities;

public partial class Quality : BaseEntity
{
    public string Quality1 { get; set; } = null!;
    public virtual ICollection<Video> Videos { get; set; } = new List<Video>();
}
