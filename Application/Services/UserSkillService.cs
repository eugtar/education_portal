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

    public async Task CreateAsync(int userId, int skillId)
    {
        await _unitOfWork.UserSkills.AddAsync(new UserSkill()
        {
            UserId = userId,
            SkillId = skillId
        });

        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int userId, int skillId)
    {
        var userSkill = await _unitOfWork.UserSkills.GetByIdAsync(skillId);

        if (userSkill is not null)
        {
            await _unitOfWork.UserSkills.RemoveAsync(userSkill);
            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task<List<UserSkill>> GetAllAsync(int userId)
    {
        return [.. await _unitOfWork.UserSkills.FindAllAsync(us => us.UserId == userId)];
    }

    public async Task<UserSkill?> GetByIdAsync(int userId, int skillId)
    {
        return await _unitOfWork.UserSkills.GetByIdAsync(skillId);
    }

    public async Task UpdateAsync(int userId, int skillId, int? level)
    {
        var userSkill = await _unitOfWork.UserSkills.GetByIdAsync(skillId);

        if (userSkill is not null)
        {
            userSkill.Level = level ?? userSkill.Level;

            await _unitOfWork.UserSkills.UpdateAsync(userSkill);
            await _unitOfWork.CompleteAsync();
        }
    }
}
