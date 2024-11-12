using Domain.Common;

namespace Domain.Entities;

public partial class Article : Material
{
    public required string Link { get; set; } = null!;
}
