using Application.Dtos.CourseDtos;
using FluentValidation;

namespace Application.Validators.CourseValidators;

public class CourseUpdateValidator : AbstractValidator<UpdateCourseDto>
{
    public CourseUpdateValidator()
    {
        RuleFor(course => course.Title)
            .MaximumLength(150);
        RuleFor(course => course.Description)
            .MaximumLength(150);
    }
}
