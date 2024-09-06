using Application.Services.Interfaces;
using Domain.Entities;
using Presentation.Uis.Common;
using Presentation.Uis.Interfaces;

namespace Presentation.Uis;

public class SkillUi : Ui, ISkillUi
{
    private readonly ISkillService _service;

    public SkillUi(ISkillService skillService)
    {
        _service = skillService;
    }

    public string Create()
    {
        var name = ReadText("Skill title");

        return name;
    }

    public int Delete()
    {
        var skills = _service.GetAll();

        return skills[SelectOne<Skill>(skills)].Id;
    }

    public string? Update()
    {
        var name = ReadText("Skill title", false);

        return name ?? null;
    }

    public int GetById()
    {
        var skills = _service.GetAll();

        return skills[SelectOne<Skill>(skills)].Id;
    }

    public string GetAll()
    {
        return $"[{string.Join(",\n", _service.GetAll())}]";
    }
}
