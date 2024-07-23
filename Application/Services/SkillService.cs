using Domain;

namespace Application
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepo;

        public SkillService() : this(new SkillRepository()) { }

        public SkillService(ISkillRepository skillRepository) 
        {
            _skillRepo = skillRepository;
        }

        public Skill Create(CreateSkillDto createSkillDto)
        {
            return _skillRepo.Create(createSkillDto);
        }

        public void Delete(string id)
        {
           _skillRepo.Delete(id);
        }

        public Skill? GetUnique(string id)
        {
            throw new NotImplementedException();
        }

        public List<Skill?> GetAll()
        {
            return _skillRepo.GetAll();
        }

        public Skill? Update(string id, UpdateSkillDto updateSkillDto)
        {
            throw new NotImplementedException();
        }
    }
}
