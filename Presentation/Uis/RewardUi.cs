using Application.Services.Interfaces;
using Domain.Entities;
using Presentation.Uis.Common;
using Presentation.Uis.Interfaces;

namespace Presentation.Uis;

public class RewardUi : Ui, IRewardUi
{
    private readonly IRewardService _service;

    public RewardUi(IRewardService rewardService)
    {
        _service = rewardService;
    }

    public string Create()
    {
        var name = ReadText("Skill title");

        return name;
    }

    public int Delete()
    {
        var rewards = _service.GetAll();

        return rewards[SelectOne<Reward>(rewards)].Id;
    }

    public string? Update()
    {
        var name = ReadText("Skill title", false);

        return name ?? null;
    }

    public int GetById()
    {
        var rewards = _service.GetAll();

        return rewards[SelectOne<Reward>(rewards)].Id;
    }

    public string GetAll()
    {
        return $"[{string.Join(",\n", _service.GetAll())}]";
    }
}
