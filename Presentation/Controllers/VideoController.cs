using Application.Services;
using Application.Services.Interfaces;
using Infrastructure.Data;
using Infrastructure.UnitOfWork;
using Presentation.Controllers.Interfaces;
using Presentation.Uis;
using Presentation.Uis.Common;
using Presentation.Uis.Interfaces;

namespace Presentation.Controllers;

public class VideoController : IController
{
    public readonly IVideoService _videoService;
    public readonly IVideoUi _ui;
    public readonly DatabaseContext _context;

    public VideoController(DatabaseContext context)
    {
        _context = context;
        _videoService = new VideoService(new UnitOfWork(_context));
        _ui = new VideoUi(_videoService);
    }

    public void Create()
    {
        _videoService.Create(_ui.Create());
    }

    public void Delete()
    {
        _videoService.Delete(_ui.Delete());
    }

    public void GetAll()
    {
        ConsoleAlert.Result(_ui.GetAll());
    }

    public void GetById()
    {
        ConsoleAlert.Result(_videoService.GetById(_ui.GetById()));
    }

    public void Update()
    {
        var id = _videoService.GetById(_ui.GetById())?.Id ?? throw new ArgumentNullException();
        _videoService.Update(id, _ui.Update());
    }
}
