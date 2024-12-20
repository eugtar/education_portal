using Application.Dtos.SkillDtos;
using Application.Dtos.UserDtos;
using Application.Results;

namespace Application.Services.Interfaces;

public interface ISkillService
{
    public Task<Result> CreateAsync(CreateSkillDto dto);
    public Task<Result> UpdateAsync(int id, UpdateSkillDto dto);
    public Task<Result> DeleteAsync(int id);
    public Task<Result<SkillDto>> GetByIdAsync(int id);
    public Task<Result<List<SkillDto>>> GetAllAsync();
    // UserSkill
    public Task<Result<List<UserSkillDto>>> GetAllUserSkillsAsync(int userId);
    public Task<Result<UserSkillDto>> GetUserSkillInfoAsync(int userId, int skillId);
    public Task<Result> DeleteUserSkillAsync(int userId, int skillId);
    public Task<Result> AddOrLevelUpUserSkillAsync(int userId, int skillId);
}
