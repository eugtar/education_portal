using Application.Services;
using Application.Services.Interfaces;
using Infrastructure.Data;
using Infrastructure.UnitOfWork;
using Presentation.Controllers.Interfaces;
using Presentation.Uis;
using Presentation.Uis.Common;
using Presentation.Uis.Interfaces;

namespace Presentation.Controllers;

public class ArticleController : IController
{
    private readonly IArticleService _articleService;
    private readonly IArticleUi _ui;
    private readonly DatabaseContext _context;

    public ArticleController(DatabaseContext context)
    {
        _context = context;
        _articleService = new ArticleService(new UnitOfWork(_context));
        _ui = new ArticleUi(_articleService);
    }

    public void Create()
    {
        _articleService.Create(_ui.Create());
    }

    public void Delete()
    {
        _articleService.Delete(_ui.Delete());
    }

    public void GetAll()
    {
        ConsoleAlert.Result(_ui.GetAll());
    }

    public void GetById()
    {
        ConsoleAlert.Result(_articleService.GetById(_ui.GetById()));
    }

    public void Update()
    {
        var id = _articleService.GetById(_ui.GetById())?.Id ?? throw new ArgumentNullException();
        _articleService.Update(id, _ui.Update());
    }
}
