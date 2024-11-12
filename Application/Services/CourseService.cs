using System.Net;
using Application.Dtos;
using Application.Interfaces;
using Application.Results;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class CourseService : ICourseService
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

    // UserCourses
    public async Task<Result> SubscribeToCourseAsync(int userId, int courseId)
    {
        var userCourseIsExist = await _unitOfWork.UserCourses.IsExistAsync(
            userCourse => userCourse.UserId == userId && userCourse.CourseId == courseId
        );

        if (userCourseIsExist)
        {
            return new Error(HttpStatusCode.NotFound, "User is already subscribed to this course");
        }

        await _unitOfWork.UserCourses.AddAsync(new UserCourse()
        {
            UserId = userId,
            CourseId = courseId
        });

        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    public async Task<Result> UnsubscribeFromCourseAsync(int userId, int courseId)
    {
        var userCourse = await _unitOfWork.UserCourses.FindOneAsync(
            userCourse => userCourse.UserId == userId && userCourse.CourseId == courseId
        );

        if (userCourse is null)
        {
            return new Error(HttpStatusCode.NotFound, "Not found");
        }

        await _unitOfWork.UserCourses.RemoveAsync(userCourse);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    public async Task<Result<List<UserCourse>>> GetAllUserCoursesAsync(int userId)
    {
        var userCourses = await _unitOfWork.UserCourses.FindAllAsync(
            userCourse => userCourse.UserId == userId
        );

        if (userCourses.Count() == 0)
        {
            return new Error(HttpStatusCode.NotFound, "Not found");
        }

        return userCourses.ToList();
    }

    public async Task<Result<UserCourse>> GetUserCourseInfoAsync(int userId, int courseId)
    {
        var userCourse = await _unitOfWork.UserCourses.FindOneAsync(
            userCourse => userCourse.UserId == userId && userCourse.CourseId == courseId
        );

        if (userCourse is null)
        {
            return new Error(HttpStatusCode.NotFound, "Not found");
        }

        return userCourse;
    }

    private async Task<Result> UpdateUserCourseProgressAsync(
        UserCourse userCourse, decimal? progress = 25M
    )
    {
        userCourse.Progress += progress ?? 0M;

        if (userCourse.Progress >= 99.9M)
        {
            userCourse.Progress = 100M;
            userCourse.Finished = true;

            var courseSkills = userCourse.Course.Skills;

            foreach (var skill in courseSkills)
            {
                await _skillService.AddOrLevelUpUserSkillAsync(userCourse.UserId, skill.Id);
            }
        }

        await _unitOfWork.UserCourses.UpdateAsync(userCourse);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    public async Task<Result> StudyTheCourseAsync(int userId, int courseId)
    {
        var userCourse = await _unitOfWork.UserCourses.FindOneAsync(
            userCourse => userCourse.UserId == userId && userCourse.CourseId == courseId
        );

        if (userCourse is null)
        {
            return new Error(HttpStatusCode.NotFound, "Not found");
        }

        if (userCourse.Finished)
        {
            return new Error(HttpStatusCode.BadRequest, "Course is finished");
        }

        var progress = 100M / userCourse.Course.Materials.Count();

        await UpdateUserCourseProgressAsync(userCourse, progress);

        return Result.Success();
    }
}
