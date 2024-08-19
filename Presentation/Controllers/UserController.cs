using Application.Services;
using Application.Services.Interfaces;
using Infrastructure.Data;
using Infrastructure.UnitOfWork;
using Presentation.Controllers.Interfaces;
using Presentation.Uis;
using Presentation.Uis.Common;
using Presentation.Uis.Interfaces;

namespace Presentation.Controllers;

public class UserController : IController
{
    private readonly IUserService _userService;
    private readonly IUserUi _ui;
    private readonly DatabaseContext _context;
    public UserController(DatabaseContext context)
    {
        _context = context;
        _userService = new UserService(new UnitOfWork(_context));
        _ui = new UserUi(_userService);
    }

    public void Create()
    {
        _userService.Create(_ui.Create());
    }

    public void Delete()
    {
        _userService.Delete(_ui.Delete());
    }

    public void GetAll()
    {
        ConsoleAlert.Result(_ui.GetAll());
    }

    public void GetById()
    {
        ConsoleAlert.Result(_userService.GetById(_ui.GetById()));
    }

    public void Update()
    {
        var id = _userService.GetById(_ui.GetById()).Id;
        _userService.Update(id, _ui.Update());
    }
}
