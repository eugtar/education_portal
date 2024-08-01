namespace Domain
{
    public interface ISkillRepository
    {
        public Skill Create(CreateSkillDto createSkillDto);
        public Skill Update(string id, UpdateSkillDto updateSkillDto);
        public void Delete(string id);
        public Skill GetById(string id);
        public List<Skill> GetAll();
    }
}
