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

    public async Task CreateAsync(CreateCourseDto createCourseDto)
    {
        await _unitOfWork.Courses.AddAsync(
            new Course()
            {
                Title = createCourseDto.Title,
                Description = createCourseDto.Description
            });

        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var course = await _unitOfWork.Courses.GetByIdAsync(id);

        if (course is not null)
        {
            await _unitOfWork.Courses.RemoveAsync(course);
            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task<List<Course>> GetAllAsync()
    {
        return [.. await _unitOfWork.Courses.GetAllAsync()];
    }

    public async Task<Course?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Courses.GetByIdAsync(id);
    }

    public async Task UpdateAsync(int id, UpdateCourseDto updateCourseDto)
    {
        var course = await _unitOfWork.Courses.GetByIdAsync(id);

        if (course is not null)
        {
            course.Title = updateCourseDto.Title ?? course.Title;
            course.Description = updateCourseDto.Description ?? course.Description;

            await _unitOfWork.Courses.UpdateAsync(course);
            await _unitOfWork.CompleteAsync();
        }
    }
}
