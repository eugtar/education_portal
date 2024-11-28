using Application.Dtos;
using Application.Results;
using Domain.Entities;
using Domain.Entities.UserGroup;

namespace Application.Services.Interfaces;

public interface IUserService
{
    public Task<Result> CreateAsync(CreateUserDto dto);
    public Task<Result> UpdateAsync(int id, UpdateUserDto dto);
    public Task<Result> DeleteAsync(int id);
    public Task<Result<User?>> GetByIdAsync(int id);
    public Task<Result<List<User>>> GetAllAsync();
}
