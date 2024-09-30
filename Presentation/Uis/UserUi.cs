using Application.Dtos;
using Application.Services.Interfaces;
using Domain.Entities;
using Presentation.Uis.Common;
using Presentation.Uis.Interfaces;

namespace Presentation.Uis;

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
        var email = ReadText("Email");
        var hashPassword = ReadText("Password");

        return new CreateUserDto(firstName, lastName, email, hashPassword);
    }

    public int Delete()
    {
        var users = _service.GetAll();

        return users[SelectOne<User>(users)].Id;
    }

    public string GetAll()
    {
        return $"[{string.Join(",\n", _service.GetAll())}]";
    }

    public int GetById()
    {
        var users = _service.GetAll();

        return users[SelectOne<User>(users)].Id;
    }

    public UpdateUserDto Update()
    {
        var firstName = ReadText("First name", false);
        var lastName = ReadText("Last name", false);
        var email = ReadText("Email", false);
        var hashPassword = ReadText("Password", false);

        return new UpdateUserDto(firstName, lastName, email, hashPassword);
    }
}
