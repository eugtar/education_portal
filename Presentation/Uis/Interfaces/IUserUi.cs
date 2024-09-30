using Application.Dtos;

namespace Presentation.Uis.Interfaces;

public interface IUserUi
{
    public CreateUserDto Create();
    public UpdateUserDto Update();
    public int Delete();
    public int GetById();
    public string GetAll();
}
