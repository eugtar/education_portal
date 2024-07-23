using Application;
using Domain;

namespace Presentation
{
    public class UserController : IController
    {
        IUserUi _ui;
        IUserService _userService;

        public UserController() : this(new UserUi(), new UserService()) { }

        public UserController(IUserUi ui, IUserService userService)
        {
            _ui = ui;
            _userService = userService;
        }

        public void Create()
        {
            User newUser = _userService.Create(_ui.Create());

            Console.WriteLine(newUser);
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
