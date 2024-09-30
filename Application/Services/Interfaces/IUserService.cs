using Application.Dtos;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IUserService
{
    public void Create(CreateUserDto createUserDto);
    public void Update(int id, UpdateUserDto updateUserDto);
    public void Delete(int id);
    public User? GetById(int id);
    public List<User> GetAll();
}
