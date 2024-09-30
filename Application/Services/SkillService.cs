using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class SkillService : ISkillService
{
    private readonly IUnitOfWork _unitOfWork;

    public SkillService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Create(int userId, int rewardId)
    {
        _unitOfWork.Skills.Add(new Skill()
        {
            UserId = userId,
            RewardId = rewardId
        });

        _unitOfWork.Complete();
    }

    public void Delete(int id)
    {
        var skill = _unitOfWork.Skills.GetById(id) ?? throw new ArgumentNullException();

        _unitOfWork.Skills.Remove(skill);
        _unitOfWork.Complete();
    }

    public List<Skill> GetAll()
    {
        return [.. _unitOfWork.Skills.GetAll()];
    }

    public Skill? GetById(int id)
    {
        return _unitOfWork.Skills.GetById(id) ?? throw new ArgumentNullException();
    }

    public void Update(int id, int? level)
    {
        var skill = _unitOfWork.Skills.GetById(id) ?? throw new ArgumentNullException();

        skill.Level = level ?? skill.Level;

        _unitOfWork.Skills.Update(skill);
        _unitOfWork.Complete();
    }
}
