using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IUserSkillService
{
    public void Create(int userId, int skillId);
    public void Update(int userId, int skillId, int? level);
    public void Delete(int userId, int skillId);
    public UserSkill? GetById(int userId, int skillId);
    public List<UserSkill> GetAll(int userId);
}
