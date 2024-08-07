using Application;
using Domain;

namespace Presentation
{
    public class EBookController : IController
    {
        private readonly IEBookUi _ui;
        private readonly IEBookService _eBookService;

        public EBookController() : this(new EBookService()) { }

        public EBookController(IEBookService eBookService)
        {
            _eBookService = eBookService;
            _ui = new EBookUi(_eBookService);
        }

        public void Create()
        {
            var newEBook = _eBookService.Create(_ui.Create());

            ConsoleAlert.Result(newEBook);
        }

        public void Delete()
        {
            _eBookService.Delete(_ui.Delete());
        }

        public void GetAll()
        {
            ConsoleAlert.Result(_ui.GetAll());
        }

        public void GetById()
        {
            ConsoleAlert.Result(_eBookService.GetById(_ui.GetById()));
        }

        public void Update()
        {
            var id = _eBookService.GetById(_ui.GetById()).Id;
            var eBook = _eBookService.Update(id, _ui.Update());

            ConsoleAlert.Result(eBook);
        }
    }
}
