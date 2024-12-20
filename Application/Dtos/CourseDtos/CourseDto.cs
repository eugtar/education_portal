using Application.Dtos.MaterialDtos;
using Application.Dtos.SkillDtos;
using Domain.Entities;

namespace Application.Dtos.CourseDtos;

public sealed class CourseDto
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required IEnumerable<MaterialDto> Materials { get; set; }
    public required IEnumerable<SkillDto> Skills { get; set; }
    public required DateTime? CreatedAt { get; set; }
    public required DateTime? UpdatedAt { get; set; }

    public static CourseDto MapToView(Course c)
    {
        return new CourseDto
        {
            Id = c.Id,
            Title = c.Title,
            Description = c.Description,
            CreatedAt = c.CreatedAt,
            UpdatedAt = c.UpdatedAt,
            Materials = c.Materials.Select(m => MaterialDto.MapToView(m)),
            Skills = c.Skills.Select(s => SkillDto.MapToView(s))
        };
    }
}
