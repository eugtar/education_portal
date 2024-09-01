using Application.Dtos;
using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Create(int userId, int lessonId)
    {
        _unitOfWork.Courses.Add(new Course()
        {
            UserId = userId,
            LessonId = lessonId
        });

        _unitOfWork.Complete();
    }

    public void Delete(int id)
    {
        var course = _unitOfWork.Courses.GetById(id) ?? throw new ArgumentNullException();

        _unitOfWork.Courses.Remove(course);
        _unitOfWork.Complete();
    }

    public List<Course> GetAll()
    {
        return [.. _unitOfWork.Courses.GetAll()];
    }

    public Course? GetById(int id)
    {
        return _unitOfWork.Courses.GetById(id) ?? throw new ArgumentNullException();
    }

    public void Update(int id, UpdateCourseDto updateCourseDto)
    {
        var course = _unitOfWork.Courses.GetById(id) ?? throw new ArgumentNullException();

        course.Finished = updateCourseDto.Finished ?? false;
        course.Progress = updateCourseDto.Progress ?? course.Progress;

        _unitOfWork.Courses.Update(course);
        _unitOfWork.Complete();
    }
}
