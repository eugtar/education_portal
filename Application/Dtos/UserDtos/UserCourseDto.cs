using System.Globalization;
using Application.Dtos.CourseDtos;
using Domain.Entities.UserGroup;

namespace Application.Dtos.UserDtos;

public sealed class UserCourseDto
{
    public required int Id { get; set; }
    public bool Finished { get; set; }
    public required string Progress { get; set; }
    public required CourseDto Course { get; set; }
    public required DateTime? CreatedAt { get; set; }
    public required DateTime? UpdatedAt { get; set; }

    public static UserCourseDto MapToView(UserCourse uc)
    {
        return new UserCourseDto
        {
            Id = uc.Id,
            Course = CourseDto.MapToView(uc.Course),
            Finished = uc.Finished,
            Progress = uc.Progress.ToString("P", CultureInfo.InvariantCulture),
            CreatedAt = uc.CreatedAt,
            UpdatedAt = uc.UpdatedAt
        };
    }
}
