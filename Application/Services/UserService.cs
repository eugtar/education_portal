using System.Net;
using Application.Dtos.UserDtos;
using Application.Interfaces;
using Application.Results;
using Application.Services.Interfaces;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);

        if (user is null)
        {
            return new Error(HttpStatusCode.NotFound, $"User with ID: {id} not found");
        }

        await _unitOfWork.Users.RemoveAsync(user);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    public async Task<Result<List<UserDto>>> GetAllAsync()
    {
        var users = await _unitOfWork.Users.GetAllAsync();

        if (users.Count() == 0)
        {
            return new Error(HttpStatusCode.NotFound, "Not found");
        }

        return users.Select(u => UserDto.MapToView(u)).ToList();
    }

    public async Task<Result<UserDto?>> GetByIdAsync(int id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);

        if (user is null)
        {
            return new Error(HttpStatusCode.NotFound, $"User with ID: {id} not found");
        }

        return UserDto.MapToView(user);
    }
}
