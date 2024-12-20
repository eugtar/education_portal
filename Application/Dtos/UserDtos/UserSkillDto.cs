using Application.Dtos.SkillDtos;
using Domain.Entities.UserGroup;

namespace Application.Dtos.UserDtos;

public sealed class UserSkillDto
{
    public required int Id { get; set; }
    public required int Level { get; set; }
    public required SkillDto Skill { get; set; }
    public required DateTime? CreatedAt { get; set; }
    public required DateTime? UpdatedAt { get; set; }

    public static UserSkillDto MapToView(UserSkill us)
    {
        return new UserSkillDto
        {
            Id = us.Id,
            Level = us.Level,
            Skill = SkillDto.MapToView(us.Skill),
            CreatedAt = us.CreatedAt,
            UpdatedAt = us.UpdatedAt
        };
    }
}
