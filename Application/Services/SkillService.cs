using Application.Dtos;
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

    public async Task CreateAsync(CreateSkillDto createSkillDto)
    {
        await _unitOfWork.Skills.AddAsync(
            new Skill()
            {
                Name = createSkillDto.Name,
            });

        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var skill = await _unitOfWork.Skills.GetByIdAsync(id);

        if (skill is not null)
        {
            await _unitOfWork.Skills.RemoveAsync(skill);
            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task<List<Skill>> GetAllAsync()
    {
        return [.. await _unitOfWork.Skills.GetAllAsync()];
    }

    public async Task<Skill?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Skills.GetByIdAsync(id);
    }

    public async Task UpdateAsync(int id, UpdateSkillDto updateSkillDto)
    {
        var skill = await _unitOfWork.Skills.GetByIdAsync(id);

        if (skill is not null)
        {
            skill.Name = updateSkillDto.Name ?? skill.Name;

            await _unitOfWork.Skills.UpdateAsync(skill);
            await _unitOfWork.CompleteAsync();
        }
    }
}
