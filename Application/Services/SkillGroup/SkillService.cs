using System.Net;
using Application.Dtos;
using Application.Interfaces;
using Application.Results;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services.SkillGroup;

public partial class SkillService : ISkillService
{
    private readonly IUnitOfWork _unitOfWork;

    public SkillService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

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
}
