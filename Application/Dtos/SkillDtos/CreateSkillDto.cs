namespace Application.Dtos.SkillDtos;

public sealed class CreateSkillDto
{
    private string _name = null!;
    public required string Name
    {
        get => _name;
        set => _name = value.Trim().ToLower();
    }
}
