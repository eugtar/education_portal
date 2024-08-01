
namespace Domain
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        public SkillRepository() : this("skills") { }

        public SkillRepository(string name) : base(name) { }

        public Skill Create(CreateSkillDto createSkillDto)
        {
            Skill newSkill = new(
                Guid.NewGuid().ToString(),
                createSkillDto.Name,
                DateTime.Now.TimeOfDay,
                DateTime.Now.TimeOfDay
            );


            List<Skill> skills = Read();
            Write([newSkill, .. skills]);

            return newSkill;
        }

        public void Delete(string id)
        {
            List<Skill> skills = Read();
            if (skills.Count == 0)
            {
                return;
            }

            int i = skills.FindIndex(skill => skill?.Id == id);

            if (i == -1)
            {
                new NotImplementedException();
            }

            skills.RemoveAt(i);
            Write(skills);

            return;
        }

        public List<Skill> GetAll()
        {
            return Read();
        }

        public Skill GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Skill Update(string id, UpdateSkillDto updateSkillDto)
        {
            throw new NotImplementedException();
        }
    }
}