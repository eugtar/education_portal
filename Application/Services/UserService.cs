using Application.Dtos;
using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Create(CreateUserDto createUserDto)
    {
        _unitOfWork.Users.Add(
            new User()
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
                Password = createUserDto.Password,
            });

        _unitOfWork.Complete();
    }

    public void Delete(int id)
    {
        var user = _unitOfWork.Users.GetById(id) ?? throw new ArgumentNullException();

        _unitOfWork.Users.Remove(user);
        _unitOfWork.Complete();
    }

    public List<User> GetAll()
    {
        return [.. _unitOfWork.Users.GetAll()];
    }

    public User? GetById(int id)
    {
        return _unitOfWork.Users.GetById(id) ?? throw new ArgumentNullException();
    }

    public void Update(int id, UpdateUserDto updateUserDto)
    {
        var user = _unitOfWork.Users.GetById(id) ?? throw new ArgumentNullException();

        user.FirstName = updateUserDto.FirstName ?? user.FirstName;
        user.LastName = updateUserDto.LastName ?? user.LastName;
        user.Email = updateUserDto.Email ?? user.Email;
        user.Password = updateUserDto.Password ?? user.Password;

        _unitOfWork.Users.Update(user);
        _unitOfWork.Complete();
    }
}
