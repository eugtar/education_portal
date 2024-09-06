using Domain.Entities;

namespace Application.Services.Interfaces;

public interface ISkillService
{
    public void Create(string name);
    public void Update(int id, string? name);
    public void Delete(int id);
    public Skill? GetById(int id);
    public List<Skill> GetAll();
}
