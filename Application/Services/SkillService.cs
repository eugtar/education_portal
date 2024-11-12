using System.Net;
using Application.Dtos;
using Application.Interfaces;
using Application.Results;
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

    // Skills
    public async Task<Result> CreateAsync(CreateSkillDto dto)
    {
        var isSkillExist = await _unitOfWork.Skills.IsExistAsync(
                skill => skill.Name.ToLower() == dto.Name.ToLower()
            );

        if (isSkillExist)
        {
            return new Error(HttpStatusCode.BadRequest, $"Skill {dto.Name} is exist");
        }

        await _unitOfWork.Skills.AddAsync(
            new Skill()
            {
                Name = dto.Name,
            });

        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var skill = await _unitOfWork.Skills.GetByIdAsync(id);

        if (skill is null)
        {
            return new Error(HttpStatusCode.NotFound, $"Skill with ID: {id} not found");
        }

        await _unitOfWork.Skills.RemoveAsync(skill);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    public async Task<Result<List<Skill>>> GetAllAsync()
    {
        var skills = await _unitOfWork.Skills.GetAllAsync();

        if (skills.Count() == 0)
        {
            return new Error(HttpStatusCode.NotFound, "Not found");
        }

        return skills.ToList();
    }

    public async Task<Result<Skill?>> GetByIdAsync(int id)
    {
        var skill = await _unitOfWork.Skills.GetByIdAsync(id);

        if (skill is null)
        {
            return new Error(HttpStatusCode.NotFound, $"Skill with ID: {id} not found");
        }

        return skill;
    }

    public async Task<Result> UpdateAsync(int id, UpdateSkillDto dto)
    {
        var skill = await _unitOfWork.Skills.GetByIdAsync(id);

        if (skill is null)
        {
            return new Error(HttpStatusCode.NotFound, $"Skill with ID: {id} not found");
        }

        skill.Name = dto.Name ?? skill.Name;

        await _unitOfWork.Skills.UpdateAsync(skill);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    // UserSkills
    public async Task<Result<List<UserSkill>>> GetAllUserSkillsAsync(int userId)
    {
        var userSkills = await _unitOfWork.UserSkills.FindAllAsync(
            userSkill => userSkill.UserId == userId
        );

        if (userSkills.Count() == 0)
        {
            return new Error(HttpStatusCode.NotFound, "Not found");
        }

        return userSkills.ToList();
    }

    public async Task<Result<UserSkill>> GetUserSkillInfoAsync(int userId, int skillId)
    {
        var userSkill = await _unitOfWork.UserSkills.FindOneAsync(
            userSkill => userSkill.SkillId == skillId && userSkill.UserId == userId
        );

        if (userSkill is null)
        {
            return new Error(HttpStatusCode.NotFound, "Not found");
        }

        return userSkill;
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
