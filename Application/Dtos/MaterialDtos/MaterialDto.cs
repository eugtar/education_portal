using Domain.Common;

namespace Application.Dtos.MaterialDtos;

public sealed class MaterialDto
{
    public required int Id { get; set; }
    public required string Type { get; set; }
    public required string Title { get; set; }
    public required DateTime? CreatedAt { get; set; }
    public required DateTime? UpdatedAt { get; set; }

    public static MaterialDto MapToView(Material m)
    {
        return new MaterialDto
        {
            Id = m.Id,
            Type = m.Type,
            Title = m.Title,
            CreatedAt = m.CreatedAt,
            UpdatedAt = m.UpdatedAt
        };
    }
}
