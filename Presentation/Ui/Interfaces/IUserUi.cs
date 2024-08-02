using Application;

namespace Presentation
{
    public interface IUserUi
    {
        CreateUserDto Create();
        UpdateUserDto Update();
        string SelectOne();
        string Delete();
    }
}
