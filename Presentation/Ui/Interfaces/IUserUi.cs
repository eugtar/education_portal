using Application;

namespace Presentation
{
    public interface IUserUi
    {
        CreateUserDto Create();
        UpdateUserDto Update();
        string Delete();
        string GetById();
        string GetAll();
    }
}
