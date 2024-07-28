using Application;
using Domain;

namespace Presentation
{
    public class SkillUi : Ui, ISkillUi
    {
        private readonly ISkillService _service;


        public SkillUi(ISkillService skillService) 
        {
            _service = skillService;
        }


        public CreateSkillDto Create()
        {
            string name = ReadText("Skill title");

            return new CreateSkillDto(name);
        }


        public string Delete()
        {
            List<Skill?> skills = _service.GetAll();

            if(skills.Count == 0)
            {
                Console.WriteLine("Not Found");
                App.StopProcess();
            }

            return skills[SelectOne<Skill>(skills)]?.Id;
        }


        public UpdateSkillDto Update()
        {
            throw new NotImplementedException();
        }
    }
}
