using System.Net;
using Application.Dtos;
using Application.Interfaces;
using Application.Results;
using Application.Services.Interfaces;
using Domain.Entities.UserGroup;

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

    public async Task<Result<List<User>>> GetAllAsync()
    {
        var users = await _unitOfWork.Users.GetAllAsync();

        if (users.Count() == 0)
        {
            return new Error(HttpStatusCode.NotFound, "Not found");
        }

        return users.ToList();
    }

    public async Task<Result<User?>> GetByIdAsync(int id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);

        if (user is null)
        {
            return new Error(HttpStatusCode.NotFound, $"User with ID: {id} not found");
        }

        return user;
    }

    public async Task<Result> UpdateAsync(int id, UpdateUserDto dto)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);

        if (user is null)
        {
            return new Error(HttpStatusCode.NotFound, $"User with ID: {id} not found");
        }

        user.FirstName = dto.FirstName ?? user.FirstName;
        user.LastName = dto.LastName ?? user.LastName;
        user.Email = dto.Email ?? user.Email;
        user.PasswordHash = dto.Password ?? user.PasswordHash;

        await _unitOfWork.Users.UpdateAsync(user);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }
}