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

    public void Delete(int id)
    {
        var userCourse = _unitOfWork.UserCourses.GetById(id) ?? throw new ArgumentNullException();

        _unitOfWork.UserCourses.Remove(userCourse);
        _unitOfWork.Complete();
    }

    public List<UserCourse> GetAll()
    {
        return [.. _unitOfWork.UserCourses.GetAll()];
    }

    public UserCourse? GetById(int id)
    {
        return _unitOfWork.UserCourses.GetById(id) ?? throw new ArgumentNullException();
    }

    public void Update(int id, UpdateUserCourseDto updateUserCourseDto)
    {
        var userCourse = _unitOfWork.UserCourses.GetById(id) ?? throw new ArgumentNullException();

        userCourse.Finished = updateUserCourseDto.Finished ?? false;
        userCourse.Progress = updateUserCourseDto.Progress ?? userCourse.Progress;

        _unitOfWork.UserCourses.Update(userCourse);
        _unitOfWork.Complete();
    }
}
