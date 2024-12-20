using Application.Dtos.CourseDtos;
using Application.Dtos.UserDtos;
using Application.Results;

namespace Application.Services.Interfaces;

public interface ICourseService
{
    public Task<Result> CreateAsync(CreateCourseDto dto);
    public Task<Result> UpdateAsync(int id, UpdateCourseDto dto);
    public Task<Result> DeleteAsync(int id);
    public Task<Result<CourseDto>> GetByIdAsync(int id);
    public Task<Result<List<CourseDto>>> GetAllAsync();
    // UserCourse
    public Task<Result> SubscribeToCourseAsync(int userId, int courseId);
    public Task<Result> UnsubscribeFromCourseAsync(int userId, int courseId);
    public Task<Result<List<UserCourseDto>>> GetAllUserCoursesAsync(int userId);
    public Task<Result<UserCourseDto>> GetUserCourseInfoAsync(int userId, int courseId);
    public Task<Result> StudyTheCourseAsync(int userId, int courseId);
}
