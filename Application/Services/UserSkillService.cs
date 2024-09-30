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

    public void Delete(int id)
    {
        var userSkill = _unitOfWork.UserSkills.GetById(id) ?? throw new ArgumentNullException();

        _unitOfWork.UserSkills.Remove(userSkill);
        _unitOfWork.Complete();
    }

    public List<UserSkill> GetAll()
    {
        return [.. _unitOfWork.UserSkills.GetAll()];
    }

    public UserSkill? GetById(int id)
    {
        return _unitOfWork.UserSkills.GetById(id) ?? throw new ArgumentNullException();
    }

    public void Update(int id, int? level)
    {
        var userSkill = _unitOfWork.UserSkills.GetById(id) ?? throw new ArgumentNullException();

        userSkill.Level = level ?? userSkill.Level;

        _unitOfWork.UserSkills.Update(userSkill);
        _unitOfWork.Complete();
    }
}
