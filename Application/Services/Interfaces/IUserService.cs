using Application.Dtos.UserDtos;
using Application.Results;

namespace Application.Services.Interfaces;

public interface IUserService
{
    public Task<Result> DeleteAsync(int id);
    public Task<Result<UserDto?>> GetByIdAsync(int id);
    public Task<Result<List<UserDto>>> GetAllAsync();
}
