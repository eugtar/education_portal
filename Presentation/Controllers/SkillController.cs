using Application;

namespace Presentation
{
    public class SkillController : IController
    {
        private readonly ISkillService _skillService;
        private readonly ISkillUi _ui;

        public SkillController() : this(new SkillService()) { }

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
            _ui = new SkillUi(_skillService);
        }

        public void Create()
        {
            var newSkill = _skillService.Create(_ui.Create());

            ConsoleAlert.Result(newSkill);
        }

        public void Delete()
        {
            _skillService.Delete(_ui.Delete());
        }

        public void GetAll()
        {
            ConsoleAlert.Result(_ui.GetAll());
        }

        public void GetById()
        {
            ConsoleAlert.Result(_skillService.GetById(_ui.GetById()));
        }

        public void Update()
        {
            var id = _skillService.GetById(_ui.GetById()).Id;
            var skill = _skillService.Update(id, _ui.Update());

            ConsoleAlert.Result(skill);
        }
    }
}
