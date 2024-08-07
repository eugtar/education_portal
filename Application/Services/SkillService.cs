using Domain;
using Infrastructure;

namespace Application
{
    public class SkillService : ISkillService
    {
        private readonly IGenericRepository<Skill> _repository;

        public SkillService() : this(new GenericRepository<Skill>("skill")) { }

        public SkillService(IGenericRepository<Skill> skillRepository)
        {
            _repository = skillRepository;
        }

        public Skill Create(string name)
        {
            var newSkill = new Skill(
                Guid.NewGuid().ToString(),
                name,
                DateTime.Now.TimeOfDay,
                DateTime.Now.TimeOfDay
            );

            return _repository.Insert(newSkill) ? newSkill : throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public List<Skill> GetAll()
        {
            var skills = _repository.GetAll().ToList();

            return skills.Count == 0 ? throw new NotImplementedException() : skills;
        }

        public Skill GetById(string id)
        {
            return _repository.GetById(id) ?? throw new NotImplementedException();
        }

        public Skill Update(string id, string? name)
        {
            var skill = _repository.GetById(id) ?? throw new NotImplementedException();

            skill.Name = name ?? skill.Name;
            skill.UpdatedAt = DateTime.Now.TimeOfDay;

            return _repository.Update(skill) ? skill : throw new NotImplementedException();
        }
    }
}
