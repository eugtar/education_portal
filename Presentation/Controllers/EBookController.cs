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
            EBook newEBook = _eBookService.Create(_ui.Create());

            Logger.LogResult(newEBook);
        }

        public void Delete()
        {
            _eBookService.Delete(_ui.Delete());
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
