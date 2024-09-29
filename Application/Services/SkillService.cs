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

    public void Create(CreateSkillDto createSkillDto)
    {
        _unitOfWork.Skills.Add(
            new Skill()
            {
                Name = createSkillDto.Name,
            });

        _unitOfWork.Complete();
    }

    public void Delete(int id)
    {
        var skill = _unitOfWork.Skills.GetById(id);

        _unitOfWork.Skills.Remove(skill);
        _unitOfWork.Complete();
    }

    public List<Skill> GetAll()
    {
        return [.. _unitOfWork.Skills.GetAll()];
    }

    public Skill? GetById(int id)
    {
        return _unitOfWork.Skills.GetById(id);
    }

    public void Update(int id, UpdateSkillDto updateSkillDto)
    {
        var skill = _unitOfWork.Skills.GetById(id);

        skill.Name = updateSkillDto.Name ?? skill.Name;

        _unitOfWork.Skills.Update(skill);
        _unitOfWork.Complete();
    }
}
