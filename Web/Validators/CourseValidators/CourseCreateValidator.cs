using Application.Dtos.CourseDtos;
using FluentValidation;

namespace Application.Validators.CourseValidators;

public sealed class CourseCreateValidator : AbstractValidator<CreateCourseDto>
{
    public CourseCreateValidator()
    {
        RuleFor(course => course.Title)
            .MaximumLength(150)
            .NotEmpty().WithMessage("Title is required");
        RuleFor(course => course.Description)
            .MaximumLength(150)
            .NotEmpty().WithMessage("Description is required");
    }
}
