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

    public void Create(CreateCourseDto createCourseDto)
    {
        _unitOfWork.Courses.Add(
            new Course()
            {
                Title = createCourseDto.Title,
                Description = createCourseDto.Description
            });

        _unitOfWork.Complete();
    }

    public void Delete(int id)
    {
        var course = _unitOfWork.Courses.GetById(id);

        _unitOfWork.Courses.Remove(course);
        _unitOfWork.Complete();
    }

    public List<Course> GetAll()
    {
        return [.. _unitOfWork.Courses.GetAll()];
    }

    public Course? GetById(int id)
    {
        return _unitOfWork.Courses.GetById(id);
    }

    public void Update(int id, UpdateCourseDto updateCourseDto)
    {
        var course = _unitOfWork.Courses.GetById(id);

        course.Title = updateCourseDto.Title ?? course.Title;
        course.Description = updateCourseDto.Description ?? course.Description;

        _unitOfWork.Courses.Update(course);
        _unitOfWork.Complete();
    }
}
