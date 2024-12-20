using Domain.Entities.RoleGroup;

namespace Application.Dtos.RoleDtos;

public sealed class RoleDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required DateTime? CreatedAt { get; set; }
    public required DateTime? UpdatedAt { get; set; }

    public static RoleDto MapToView(Role r)
    {
        return new RoleDto
        {
            Id = r.Id,
            Name = r.Name ?? "",
            CreatedAt = r.CreatedAt,
            UpdatedAt = r.UpdatedAt
        };
    }
}
