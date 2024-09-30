using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IUserSkillService
{
    public void Create(int userId, int skillId);
    public void Update(int id, int? level);
    public void Delete(int id);
    public UserSkill? GetById(int id);
    public List<UserSkill> GetAll();
}
