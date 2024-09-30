using Application.Services;
using Application.Services.Interfaces;
using Infrastructure.Data;
using Infrastructure.UnitOfWork;
using Presentation.Controllers.Interfaces;
using Presentation.Uis;
using Presentation.Uis.Common;
using Presentation.Uis.Interfaces;

namespace Presentation.Controllers;

public class EbookController : IController
{
    private readonly IEbookUi _ui;
    private readonly IEbookService _ebookService;
    private readonly DatabaseContext _context;

    public EbookController(DatabaseContext context)
    {
        _context = context;
        _ebookService = new EBookService(new UnitOfWork(_context));
        _ui = new EbookUi(_ebookService);
    }

    public void Create()
    {
        _ebookService.Create(_ui.Create());
    }

    public void Delete()
    {
        _ebookService.Delete(_ui.Delete());
    }

    public void GetAll()
    {
        ConsoleAlert.Result(_ui.GetAll());
    }

    public void GetById()
    {
        ConsoleAlert.Result(_ebookService.GetById(_ui.GetById()));
    }

    public void Update()
    {
        var id = _ebookService.GetById(_ui.GetById())?.Id ?? throw new ArgumentNullException();
        _ebookService.Update(id, _ui.Update());
    }
}
