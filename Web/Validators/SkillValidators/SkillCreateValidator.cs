using Application.Dtos.SkillDtos;
using FluentValidation;

namespace Application.Validators.SkillValidators;

public sealed class SkillCreateValidator : AbstractValidator<CreateSkillDto>
{
    public SkillCreateValidator()
    {
        RuleFor(skill => skill.Name)
            .MaximumLength(50)
            .NotEmpty().WithMessage("Skill name is required");
    }
}
