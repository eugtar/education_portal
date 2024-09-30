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
    public class RewardController : IController
    {
        private readonly IRewardService _rewardService;
        private readonly IRewardUi _ui;
        private readonly DatabaseContext _context;

        public RewardController(DatabaseContext context)
        {
            _context = context;
            _rewardService = new RewardService(new UnitOfWork(_context));
            _ui = new RewardUi(_rewardService);
        }

        public void Create()
        {
            _rewardService.Create(_ui.Create());
        }

        public void Delete()
        {
            _rewardService.Delete(_ui.Delete());
        }

        public void GetAll()
        {
            ConsoleAlert.Result(_ui.GetAll());
        }

        public void GetById()
        {
            ConsoleAlert.Result(_rewardService.GetById(_ui.GetById()));
        }

        public void Update()
        {
            var id = _rewardService.GetById(_ui.GetById())?.Id ?? throw new ArgumentNullException();
            _rewardService.Update(id, _ui.Update());
        }
    }
}
