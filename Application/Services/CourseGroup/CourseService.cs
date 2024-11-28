using System.Net;
using Application.Dtos;
using Application.Interfaces;
using Application.Results;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services.CourseGroup;

public partial class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISkillService _skillService;

    public CourseService(IUnitOfWork unitOfWork, ISkillService skillService)
    {
        _unitOfWork = unitOfWork;
        _skillService = skillService;
    }

    // Courses
    public async Task<Result> CreateAsync(CreateCourseDto dto)
    {
        await _unitOfWork.Courses.AddAsync(
            new Course()
            {
                Title = dto.Title,
                Description = dto.Description
            });

        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var course = await _unitOfWork.Courses.GetByIdAsync(id);

        if (course is null)
        {
            return new Error(HttpStatusCode.NotFound, $"Course with ID: {id} not found");
        }

        await _unitOfWork.Courses.RemoveAsync(course);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    public async Task<Result<List<Course>>> GetAllAsync()
    {
        var courses = await _unitOfWork.Courses.GetAllAsync();

        if (courses.Count() == 0)
        {
            return new Error(HttpStatusCode.NotFound, $"Not found");
        }

        return courses.ToList();
    }

    public async Task<Result<Course?>> GetByIdAsync(int id)
    {
        var course = await _unitOfWork.Courses.GetByIdAsync(id);

        if (course is null)
        {
            return new Error(HttpStatusCode.NotFound, $"Course with ID: {id} not found");
        }

        return course;
    }

    public async Task<Result> UpdateAsync(int id, UpdateCourseDto dto)
    {
        var course = await _unitOfWork.Courses.GetByIdAsync(id);

        if (course is null)
        {
            return new Error(HttpStatusCode.NotFound, $"Course with ID: {id} not found");
        }

        course.Title = dto.Title ?? course.Title;
        course.Description = dto.Description ?? course.Description;

        await _unitOfWork.Courses.UpdateAsync(course);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }
}
