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
            return _repository.Create(createSkillDto);
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
            return _repository.GetAll();
        }

        public Skill Update(string id, UpdateSkillDto updateSkillDto)
        {
            throw new NotImplementedException();
        }
    }
}
