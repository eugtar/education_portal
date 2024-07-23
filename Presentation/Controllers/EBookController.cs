using Application;
using Domain;

namespace Presentation
{
    public class EBookController : IController
    {
        IEBookUi _ui;
        IEBookService _eBookService;

        public EBookController() : this(new EBookUi(), new EBookService()) { }

        public EBookController(IEBookUi ui, IEBookService eBookService)
        {
            _ui = ui;
            _eBookService = eBookService;
        }

        public void Create()
        {
            EBook newEBook = _eBookService.Create(_ui.Create());

            Console.WriteLine(newEBook);
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
