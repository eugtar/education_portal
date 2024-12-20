namespace Application.Dtos.SkillDtos;

public sealed class UpdateSkillDto
{
    private string? _name;
    public required string? Name
    {
        get => _name;
        set => _name = value;
    }
}
