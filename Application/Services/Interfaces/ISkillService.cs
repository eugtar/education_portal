using Domain;

namespace Application
{
    public interface ISkillService
    {
        public Skill Create(string name);
        public Skill Update(string id, string? name);
        public void Delete(string id);
        public Skill GetById(string id);
        public List<Skill> GetAll();
    }
}
