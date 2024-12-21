namespace Application.Dtos.CourseDtos;

public sealed class CreateCourseDto
{
    private string _title = null!;
    private string _description = null!;
    private IEnumerable<CourseMaterialDto> _materials = null!;
    private IEnumerable<CourseSkillDto> _skills = null!;
    public required string Title
    {
        get => _title;
        set => _title = value.Trim().ToLower();
    }
    public required string Description
    {
        get => _description;
        set => _description = value.Trim().ToLower();
    }
    public required IEnumerable<CourseMaterialDto> Materials
    {
        get => _materials;
        set => _materials = value;
    }
    public required IEnumerable<CourseSkillDto> Skills
    {
        get => _skills;
        set => _skills = value;
    }
}
