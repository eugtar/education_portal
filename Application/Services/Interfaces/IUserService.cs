using Application.Dtos;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IUserService
{
    public Task CreateAsync(CreateUserDto createUserDto);
    public Task UpdateAsync(int id, UpdateUserDto updateUserDto);
    public Task DeleteAsync(int id);
    public Task<User?> GetByIdAsync(int id);
    public Task<List<User>> GetAllAsync();
}
