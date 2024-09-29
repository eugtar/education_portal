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

    public void Create(int userId, int courseId)
    {
        _unitOfWork.UserCourses.Add(new UserCourse()
        {
            UserId = userId,
            CourseId = courseId
        });

        _unitOfWork.Complete();
    }

    public void Delete(int userId, int courseId)
    {
        var userCourse = _unitOfWork.UserCourses.GetById(courseId);

        _unitOfWork.UserCourses.Remove(userCourse);
        _unitOfWork.Complete();
    }

    public List<UserCourse> GetAll(int userId)
    {
        return [.. _unitOfWork.UserCourses.Find(uc => uc.UserId == userId)];
    }

    public UserCourse? GetById(int userId, int courseId)
    {
        return _unitOfWork.UserCourses.GetById(courseId);
    }

    public void Update(int userId, int courseId, UpdateUserCourseDto updateUserCourseDto)
    {
        var userCourse = _unitOfWork.UserCourses.GetById(courseId);

        userCourse.Finished = updateUserCourseDto.Finished ?? false;
        userCourse.Progress = updateUserCourseDto.Progress ?? userCourse.Progress;

        _unitOfWork.UserCourses.Update(userCourse);
        _unitOfWork.Complete();
    }
}
