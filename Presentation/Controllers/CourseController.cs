using Application.Services;
using Application.Services.Interfaces;
using Infrastructure.Data;
using Infrastructure.UnitOfWork;
using Presentation.Controllers.Interfaces;
using Presentation.Uis;
using Presentation.Uis.Common;
using Presentation.Uis.Interfaces;

namespace Presentation.Controllers;

public class CourseController : IController
{
    private readonly ICourseService _courseService;
    private readonly ICourseUi _ui;
    private readonly DatabaseContext _context;

    public CourseController(DatabaseContext context)
    {
        _context = context;
        _courseService = new CourseService(new UnitOfWork(_context));
        _ui = new CourseUi(_courseService);
    }

    public void Create()
    {
         _courseService.Create(_ui.Create());
    }

    public void Delete()
    {
        _courseService.Delete(_ui.Delete());
    }

    public void GetAll()
    {
        ConsoleAlert.Result(_ui.GetAll());
    }

    public void GetById()
    {
        ConsoleAlert.Result(_courseService.GetById(_ui.GetById()));
    }

    public void Update()
    {
        var id = _courseService.GetById(_ui.GetById())?.Id ?? throw new ArgumentNullException();
        _courseService.Update(id, _ui.Update());
    }
}
