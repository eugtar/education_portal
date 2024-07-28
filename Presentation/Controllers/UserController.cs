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
            User newUser = _userService.Create(_ui.Create());

            Logger.LogResult(newUser);
        }

        public void Delete()
        {
            _userService.Delete(_ui.Delete());
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetUnique()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
