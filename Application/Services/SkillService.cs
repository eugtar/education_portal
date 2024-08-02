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

        public Skill Create(CreateSkillDto createSkillDto)
        {
            Skill newSkill = new(
                Guid.NewGuid().ToString(),
                createSkillDto.Name,
                DateTime.Now.TimeOfDay,
                DateTime.Now.TimeOfDay
            );

            return _repository.Insert(newSkill) ? newSkill : throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public Skill GetById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Skill> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public Skill Update(string id, UpdateSkillDto updateSkillDto)
        {
            throw new NotImplementedException();
        }
    }
}
