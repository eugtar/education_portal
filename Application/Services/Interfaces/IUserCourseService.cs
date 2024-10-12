using Application.Dtos;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IUserCourseService
{
    public Task CreateAsync(int userId, int courseId);
    public Task UpdateAsync(int userId, int courseId, UpdateUserCourseDto updateUserCourseDto);
    public Task DeleteAsync(int userId, int courseId);
    public Task<UserCourse?> GetByIdAsync(int userId, int courseId);
    public Task<List<UserCourse>> GetAllAsync(int userId);
}
