using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class UserSkillService : IUserSkillService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserSkillService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Create(int userId, int skillId)
    {
        _unitOfWork.UserSkills.Add(new UserSkill()
        {
            UserId = userId,
            SkillId = skillId
        });

        _unitOfWork.Complete();
    }

    public void Delete(int userId, int skillId)
    {
        var userSkill = _unitOfWork.UserSkills.GetById(skillId);

        _unitOfWork.UserSkills.Remove(userSkill);
        _unitOfWork.Complete();
    }

    public List<UserSkill> GetAll(int userId)
    {
        return [.. _unitOfWork.UserSkills.Find(us => us.UserId == userId)];
    }

    public UserSkill? GetById(int userId, int skillId)
    {
        return _unitOfWork.UserSkills.GetById(skillId);
    }

    public void Update(int userId, int skillId, int? level)
    {
        var userSkill = _unitOfWork.UserSkills.GetById(skillId);

        userSkill.Level = level ?? userSkill.Level;

        _unitOfWork.UserSkills.Update(userSkill);
        _unitOfWork.Complete();
    }
}
