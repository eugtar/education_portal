using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class RewardService : IRewardService
{
    private readonly IUnitOfWork _unitOfWork;

    public RewardService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Create(string name)
    {
        _unitOfWork.Rewards.Add(
            new Reward()
            {
                Name = name,
            });

        _unitOfWork.Complete();
    }

    public void Delete(int id)
    {
        var reward = _unitOfWork.Rewards.GetById(id) ?? throw new ArgumentNullException();

        _unitOfWork.Rewards.Remove(reward);
        _unitOfWork.Complete();
    }

    public List<Reward> GetAll()
    {
        return [.. _unitOfWork.Rewards.GetAll()];
    }

    public Reward? GetById(int id)
    {
        return _unitOfWork.Rewards.GetById(id) ?? throw new ArgumentNullException();
    }

    public void Update(int id, string? name)
    {
        var reward = _unitOfWork.Rewards.GetById(id) ?? throw new ArgumentNullException();

        reward.Name = name ?? reward.Name;

        _unitOfWork.Rewards.Update(reward);
        _unitOfWork.Complete();
    }
}
