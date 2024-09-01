using Domain.Entities;

namespace Application.Services.Interfaces;

public interface ISkillService
{
    public void Create(int userId, int rewardId);
    public void Update(int id, int? level);
    public void Delete(int id);
    public Skill? GetById(int id);
    public List<Skill> GetAll();
}
