using Application.Dtos;
using Application.Results;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface ICourseService
{
    public Task<Result> CreateAsync(CreateCourseDto dto);
    public Task<Result> UpdateAsync(int id, UpdateCourseDto dto);
    public Task<Result> DeleteAsync(int id);
    public Task<Result<Course?>> GetByIdAsync(int id);
    public Task<Result<List<Course>>> GetAllAsync();
    // UserCourse
    public Task<Result> SubscribeToCourseAsync(int userId, int courseId);
    public Task<Result> UnsubscribeFromCourseAsync(int userId, int courseId);
    public Task<Result<List<UserCourse>>> GetAllUserCoursesAsync(int userId);
    public Task<Result<UserCourse>> GetUserCourseInfoAsync(int userId, int courseId);
    public Task<Result> StudyTheCourseAsync(int userId, int courseId);
}
