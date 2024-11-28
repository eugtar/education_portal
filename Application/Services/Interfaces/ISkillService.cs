using Application.Dtos;
using Application.Results;
using Domain.Entities;
using Domain.Entities.UserGroup;

namespace Application.Services.Interfaces;

public interface ISkillService
{
    public Task<Result> CreateAsync(CreateSkillDto dto);
    public Task<Result> UpdateAsync(int id, UpdateSkillDto dto);
    public Task<Result> DeleteAsync(int id);
    public Task<Result<Skill?>> GetByIdAsync(int id);
    public Task<Result<List<Skill>>> GetAllAsync();
    // UserSkill
    public Task<Result<List<UserSkill>>> GetAllUserSkillsAsync(int userId);
    public Task<Result<UserSkill>> GetUserSkillInfoAsync(int userId, int skillId);
    public Task<Result> DeleteUserSkillAsync(int userId, int skillId);
    public Task<Result> AddOrLevelUpUserSkillAsync(int userId, int skillId);
}
