using Application;
using Domain;

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
            throw new NotImplementedException();
        }

        public void GetById()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
