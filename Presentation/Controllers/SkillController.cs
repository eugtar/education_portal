using Application.Services;
using Application.Services.Interfaces;
using Infrastructure.Data;
using Infrastructure.UnitOfWork;
using Presentation.Controllers.Interfaces;
using Presentation.Uis;
using Presentation.Uis.Common;
using Presentation.Uis.Interfaces;

namespace Presentation.Controllers
{
    public class SkillController : IController
    {
        private readonly ISkillService _skillService;
        private readonly ISkillUi _ui;
        private readonly DatabaseContext _context;

        public SkillController(DatabaseContext context)
        {
            _context = context;
            _skillService = new SkillService(new UnitOfWork(_context));
            _ui = new SkillUi(_skillService);
        }

        public void Create()
        {
            _skillService.Create(_ui.Create());
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
            var id = _skillService.GetById(_ui.GetById())?.Id ?? throw new ArgumentNullException();
            _skillService.Update(id, _ui.Update());
        }
    }
}
