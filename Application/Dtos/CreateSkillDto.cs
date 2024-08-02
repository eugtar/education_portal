namespace Application
{
    public class CreateSkillDto
    {
        public string Name { get; set; }

        public CreateSkillDto(string name)
        {
            Name = name;
        }
    }
}
