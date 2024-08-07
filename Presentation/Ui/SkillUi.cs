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

            return skills[SelectOne<Skill>(skills)].Id;
        }

        public string? Update()
        {
            var name = ReadText("Skill title", false);

            return name ?? null;
        }

        public string GetById()
        {
            var skills = _service.GetAll();

            return skills[SelectOne<Skill>(skills)].Id;
        }

        public string GetAll()
        {
            return $"[{string.Join(",\n", _service.GetAll())}]";
        }
    }
}
