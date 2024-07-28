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
            string firstName = ReadText("First name");
            string lastName = ReadText("Last name");

            return new CreateUserDto(firstName, lastName);
        }


        public string Delete()
        {
            List<User?> users = _service.GetAll();

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
