using Domain.Entities;
using Domain.Entities.UserGroup;

namespace Application.Dtos.SkillDtos;

public sealed class SkillDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required DateTime? CreatedAt { get; set; }
    public required DateTime? UpdatedAt { get; set; }

    public static SkillDto MapToView(Skill s)
    {
        return new SkillDto
        {
            Id = s.Id,
            Name = s.Name,
            CreatedAt = s.CreatedAt,
            UpdatedAt = s.UpdatedAt
        };
    }
}
