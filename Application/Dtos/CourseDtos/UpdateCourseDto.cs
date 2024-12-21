namespace Application.Dtos.CourseDtos;

public sealed class UpdateCourseDto
{
    private string? _title;
    private string? _description;
    private IEnumerable<CourseMaterialDto>? _materials;
    private IEnumerable<CourseSkillDto>? _skills;
    public required string? Title
    {
        get => _title;
        set => _title = value?.Trim().ToLower();
    }
    public required string? Description
    {
        get => _description;
        set => _description = value?.Trim().ToLower();
    }
    public required IEnumerable<CourseMaterialDto>? Materials
    {
        get => _materials;
        set => _materials = value;
    }
    public required IEnumerable<CourseSkillDto>? Skills
    {
        get => _skills;
        set => _skills = value;
    }
}
