using Application.Services;
using Application.Services.Interfaces;
using Infrastructure.Data;
using Infrastructure.UnitOfWork;
using Presentation.Controllers.Interfaces;
using Presentation.Uis;
using Presentation.Uis.Common;
using Presentation.Uis.Interfaces;

namespace Presentation.Controllers;

public class LessonController : IController
{
    private readonly ILessonService _lessonService;
    private readonly ILessonUi _ui;
    private readonly DatabaseContext _context;

    public LessonController(DatabaseContext context)
    {
        _context = context;
        _lessonService = new LessonService(new UnitOfWork(_context));
        _ui = new LessonUi(_lessonService);
    }

    public void Create()
    {
         _lessonService.Create(_ui.Create());
    }

    public void Delete()
    {
        _lessonService.Delete(_ui.Delete());
    }

    public void GetAll()
    {
        ConsoleAlert.Result(_ui.GetAll());
    }

    public void GetById()
    {
        ConsoleAlert.Result(_lessonService.GetById(_ui.GetById()));
    }

    public void Update()
    {
        var id = _lessonService.GetById(_ui.GetById())?.Id ?? throw new ArgumentNullException();
        _lessonService.Update(id, _ui.Update());
    }
}
