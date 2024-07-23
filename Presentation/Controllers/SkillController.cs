using Application;
using Domain;

namespace Presentation
{
    public class SkillController : IController
    {
        ISkillUi _ui;
        ISkillService _skillService;

        public SkillController() : this(new SkillUi(), new  SkillService()) { }

        public SkillController(ISkillUi ui, ISkillService skillService)
        {
            _ui = ui;
            _skillService = skillService;
        }

        public void Create()
        {
            Skill newSkill = _skillService.Create(_ui.Create());

            Console.WriteLine(newSkill);
        }

        public void Delete()
        {
            _skillService.Delete(_ui.Delete());
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetUnique()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
