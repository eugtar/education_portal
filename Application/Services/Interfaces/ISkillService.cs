using Application.Dtos;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface ISkillService
{
    public Task CreateAsync(CreateSkillDto createSkillDto);
    public Task UpdateAsync(int id, UpdateSkillDto updateSkillDto);
    public Task DeleteAsync(int id);
    public Task<Skill?> GetByIdAsync(int id);
    public Task<List<Skill>> GetAllAsync();
}
