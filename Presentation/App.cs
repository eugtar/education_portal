using System.Diagnostics;

namespace Presentation
{
    public class App
    {
        private readonly Ui _ui = new();
        private string _route = "";
        private string _action = "";
        private readonly Dictionary<string, IController> _routes = new()
        {
            { "user", new UserController() },
            { "course", new CourseController() },
            { "ebook", new EBookController() },
            { "article", new ArticleController() },
            { "video", new VideoController() },
            { "skill", new SkillController() }
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
                case "delete":
                    _routes[this._route].Delete();
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
            List<string> actions = ["create", "delete"];
            _action = actions[_ui.SelectOne(actions)];
        }

        public static void StopProcess()
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
