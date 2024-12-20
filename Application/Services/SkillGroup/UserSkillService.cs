using System.Net;
using Application.Dtos.UserDtos;
using Application.Results;
using Domain.Entities.UserGroup;

namespace Application.Services.SkillGroup;

public partial class SkillService
{
    public async Task<Result<List<UserSkillDto>>> GetAllUserSkillsAsync(int userId)
    {
        var userSkills = await _unitOfWork.UserSkills.FindAllAsync(
            userSkill => userSkill.UserId == userId
        );

        if (userSkills.Count() == 0)
        {
            return new Error(HttpStatusCode.NotFound, "Not found");
        }

        return userSkills.Select(us => UserSkillDto.MapToView(us)).ToList();
    }

    public async Task<Result<UserSkillDto>> GetUserSkillInfoAsync(int userId, int skillId)
    {
        var userSkill = await _unitOfWork.UserSkills.FindOneAsync(
            userSkill => userSkill.SkillId == skillId && userSkill.UserId == userId
        );

        if (userSkill is null)
        {
            return new Error(HttpStatusCode.NotFound, "Not found");
        }

        return UserSkillDto.MapToView(userSkill);
    }

    public async Task<Result> DeleteUserSkillAsync(int userId, int skillId)
    {
        var userSkill = await _unitOfWork.UserSkills.FindOneAsync(
            userSkill => userSkill.SkillId == skillId && userSkill.UserId == userId
        );

        if (userSkill is null)
        {
            return new Error(HttpStatusCode.NotFound, "Not found");
        }

        await _unitOfWork.UserSkills.RemoveAsync(userSkill);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    public async Task<Result> AddOrLevelUpUserSkillAsync(int userId, int skillId)
    {
        var userSkill = await _unitOfWork.UserSkills.FindOneAsync(
            userSkill => userSkill.SkillId == skillId && userSkill.UserId == userId
        );

        if (userSkill is null)
        {
            return await AddSkillToUserAsync(userId, skillId);
        }

        return await UpdateUserSkillLevelAsync(userSkill);
    }

    private async Task<Result> AddSkillToUserAsync(int userId, int skillId)
    {
        await _unitOfWork.UserSkills.AddAsync(new UserSkill()
        {
            UserId = userId,
            SkillId = skillId
        });

        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    private async Task<Result> UpdateUserSkillLevelAsync(UserSkill userSkill, int? levelPoint = 1)
    {
        userSkill.Level += levelPoint ?? 0;

        await _unitOfWork.UserSkills.UpdateAsync(userSkill);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }
}
