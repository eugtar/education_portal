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

    public async Task CreateAsync(CreateUserDto createUserDto)
    {
        await _unitOfWork.Users.AddAsync(
            new User()
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
                HashPassword = createUserDto.Password,
            });

        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);

        if (user is not null)
        {
            await _unitOfWork.Users.RemoveAsync(user);
            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task<List<User>> GetAllAsync()
    {
        return [.. await _unitOfWork.Users.GetAllAsync()];
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Users.GetByIdAsync(id);
    }

    public async Task UpdateAsync(int id, UpdateUserDto updateUserDto)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);

        if (user is not null)
        {
            user.FirstName = updateUserDto.FirstName ?? user.FirstName;
            user.LastName = updateUserDto.LastName ?? user.LastName;
            user.Email = updateUserDto.Email ?? user.Email;
            user.HashPassword = updateUserDto.Password ?? user.HashPassword;

            await _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.CompleteAsync();
        }
    }
}
