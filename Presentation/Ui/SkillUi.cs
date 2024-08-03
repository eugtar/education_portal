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


        public string Create()
        {
            var name = ReadText("Skill title");

            return name;
        }


        public string Delete()
        {
            var skills = _service.GetAll();

            if (skills.Count == 0)
            {
                Console.WriteLine("Not Found");
                App.StopProcess();
            }

            return skills[SelectOne<Skill>(skills)]?.Id;
        }


        public string Update()
        {
            throw new NotImplementedException();
        }
    }
}
