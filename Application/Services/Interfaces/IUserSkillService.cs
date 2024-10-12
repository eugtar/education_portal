using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IUserSkillService
{
    public Task CreateAsync(int userId, int skillId);
    public Task UpdateAsync(int userId, int skillId, int? level);
    public Task DeleteAsync(int userId, int skillId);
    public Task<UserSkill?> GetByIdAsync(int userId, int skillId);
    public Task<List<UserSkill>> GetAllAsync(int userId);
}
