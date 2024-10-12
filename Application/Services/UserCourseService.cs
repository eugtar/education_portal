using Application.Dtos;
using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class UserCourseService : IUserCourseService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserCourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(int userId, int courseId)
    {
        await _unitOfWork.UserCourses.AddAsync(new UserCourse()
        {
            UserId = userId,
            CourseId = courseId
        });

        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int userId, int courseId)
    {
        var userCourse = await _unitOfWork.UserCourses.GetByIdAsync(courseId);

        if (userCourse is not null)
        {
            await _unitOfWork.UserCourses.RemoveAsync(userCourse);
            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task<List<UserCourse>> GetAllAsync(int userId)
    {
        return [.. await _unitOfWork.UserCourses.FindAllAsync(uc => uc.UserId == userId)];
    }

    public async Task<UserCourse?> GetByIdAsync(int userId, int courseId)
    {
        return await _unitOfWork.UserCourses.GetByIdAsync(courseId);
    }

    public async Task UpdateAsync(int userId, int courseId, UpdateUserCourseDto updateUserCourseDto)
    {
        var userCourse = await _unitOfWork.UserCourses.GetByIdAsync(courseId);

        if (userCourse is not null)
        {
            userCourse.Finished = updateUserCourseDto.Finished ?? false;
            userCourse.Progress = updateUserCourseDto.Progress ?? userCourse.Progress;

            await _unitOfWork.UserCourses.UpdateAsync(userCourse);
            await _unitOfWork.CompleteAsync();
        }
    }
}
