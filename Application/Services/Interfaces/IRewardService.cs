using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IRewardService
{
    public void Create(string name);
    public void Update(int id, string? name);
    public void Delete(int id);
    public Reward? GetById(int id);
    public List<Reward> GetAll();
}
