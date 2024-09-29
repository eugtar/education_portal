using Application.Dtos;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface ISkillService
{
    public void Create(CreateSkillDto createSkillDto);
    public void Update(int id, UpdateSkillDto updateSkillDto);
    public void Delete(int id);
    public Skill? GetById(int id);
    public List<Skill> GetAll();
}
