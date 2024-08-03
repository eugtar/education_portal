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

            if (users.Count == 0)
            {
                Console.WriteLine("Not Found");
                App.StopProcess();
            }

            return users[SelectOne<User>(users)]?.Id;
        }

        public string SelectOne()
        {
            throw new NotImplementedException();
        }


        public UpdateUserDto Update()
        {
            throw new NotImplementedException();
        }
    }
}
