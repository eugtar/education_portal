using System.Net;
using Application.Dtos.UserDtos;
using Application.Results;
using Domain.Entities.UserGroup;

namespace Application.Services.CourseGroup;

public partial class CourseService
{
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

    public async Task<Result<List<UserCourseDto>>> GetAllUserCoursesAsync(int userId)
    {
        var userCourses = await _unitOfWork.UserCourses.FindAllAsync(
            userCourse => userCourse.UserId == userId
        );

        if (userCourses.Count() == 0)
        {
            return new Error(HttpStatusCode.NotFound, "Not found");
        }

        return userCourses.Select(uc => UserCourseDto.MapToView(uc)).ToList();
    }

    public async Task<Result<UserCourseDto>> GetUserCourseInfoAsync(int userId, int courseId)
    {
        var userCourse = await _unitOfWork.UserCourses.FindOneAsync(
            userCourse => userCourse.UserId == userId && userCourse.CourseId == courseId
        );

        if (userCourse is null)
        {
            return new Error(HttpStatusCode.NotFound, "Not found");
        }

        return UserCourseDto.MapToView(userCourse);
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
