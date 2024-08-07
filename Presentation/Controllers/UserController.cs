using Application;
using Domain;

namespace Presentation
{
    public class UserController : IController
    {
        private readonly IUserService _userService;
        private readonly IUserUi _ui;

        public UserController() : this(new UserService()) { }

        public UserController(IUserService userService)
        {
            _userService = userService;
            _ui = new UserUi(_userService);
        }

        public void Create()
        {
            var newUser = _userService.Create(_ui.Create());

            ConsoleAlert.Result(newUser);
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
            var user = _userService.Update(id, _ui.Update());

            ConsoleAlert.Result(user);
        }
    }
}
