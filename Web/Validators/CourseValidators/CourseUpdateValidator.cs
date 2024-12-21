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
        RuleFor(course => course.Materials)
            .NotEmpty().WithMessage("The course must contain at least one material");
        RuleForEach(course => course.Materials)
            .ChildRules(material =>
            {
                material.RuleFor(m => m.Id)
                    .NotEmpty().WithMessage("Material Id is required");
                material.RuleFor(m => m.Type)
                    .NotEmpty().WithMessage("Material Type is required");
                material.RuleFor(m => m.Title)
                    .NotEmpty().WithMessage("Material Title is required");
            });
        RuleFor(course => course.Skills)
            .NotEmpty().WithMessage("The course must contain at least one skill");
        RuleForEach(course => course.Skills)
            .ChildRules(material =>
            {
                material.RuleFor(m => m.Id)
                    .NotEmpty().WithMessage("Skill Id is required");
                material.RuleFor(m => m.Name)
                    .NotEmpty().WithMessage("Skill Name is required");
            });
    }
}
