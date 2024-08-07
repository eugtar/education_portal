using Application;
using Domain;

namespace Presentation
{
    public class UserUi : Ui, IUserUi
    {
        private readonly IUserService _service;

        public UserUi(IUserService userService)
        {
            _service = userService;
        }

        public CreateUserDto Create()
        {
            var firstName = ReadText("First name");
            var lastName = ReadText("Last name");

            return new CreateUserDto(firstName, lastName);
        }

        public string Delete()
        {
            var users = _service.GetAll();

            return users[SelectOne<User>(users)].Id;
        }

        public string GetAll()
        {
            return $"[{string.Join(",\n", _service.GetAll())}]";
        }

        public string GetById()
        {
            var users = _service.GetAll();

            return users[SelectOne<User>(users)].Id;
        }

        public UpdateUserDto Update()
        {
            var firstName = ReadText("First name", false);
            var lastName = ReadText("Last name", false);

            return new UpdateUserDto(firstName, lastName);
        }
    }
}
