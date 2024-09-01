using System.Diagnostics;
using Infrastructure.Data;
using Presentation.Controllers;
using Presentation.Controllers.Interfaces;
using Presentation.Uis.Common;

namespace Presentation;

public class App(DatabaseContext context)
{
    private readonly Ui _ui = new();
    private string _route = "";
    private string _action = "";
    private readonly Dictionary<string, IController> _routes = new()
        {
            { "user", new UserController(context) },
            { "lesson", new LessonController(context) },
            { "ebook", new EbookController(context) },
            { "article", new ArticleController(context) },
            { "video", new VideoController(context) },
            { "reward", new RewardController(context) }
        };

    public void Init()
    {
        while (true)
        {
            SetRoute();
            SetAction();
            Router();
        }
    }

    private void Router()
    {
        switch (_action)
        {
            case "create":
                _routes[this._route].Create();
                break;
            case "update":
                _routes[this._route].Update();
                break;
            case "delete":
                _routes[this._route].Delete();
                break;
            case "getById":
                _routes[this._route].GetById();
                break;
            case "getAll":
                _routes[this._route].GetAll();
                break;
            default:
                StopProcess();
                break;
        }
    }

    private void SetRoute()
    {
        var routes = _routes.Keys.ToList();
        _route = routes[_ui.SelectOne(routes)];
    }

    private void SetAction()
    {
        List<string> actions = ["create", "update", "delete", "getById", "getAll"];
        _action = actions[_ui.SelectOne(actions)];
    }

    public static void StopProcess()
    {
        Process.GetCurrentProcess().Kill();
    }
}
