using Application.Services;
using Application.Services.Interfaces;
using Infrastructure.Data;
using Infrastructure.UnitOfWork;
using Presentation.Controllers.Interfaces;
using Presentation.Uis;
using Presentation.Uis.Common;
using Presentation.Uis.Interfaces;

namespace Presentation.Controllers;

public class EBookController : IController
{
    private readonly IEBookUi _ui;
    private readonly IEBookService _eBookService;
    private readonly DatabaseContext _context;

    public EBookController(DatabaseContext context)
    {
        _context = context;
        _eBookService = new EBookService(new UnitOfWork(_context));
        _ui = new EBookUi(_eBookService);
    }

    public void Create()
    {
        _eBookService.Create(_ui.Create());
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
        _eBookService.Update(id, _ui.Update());
    }
}
