using Application.Dtos.SkillDtos;
using FluentValidation;

namespace Application.Validators.SkillValidators;

public class SkillUpdateValidator : AbstractValidator<UpdateSkillDto>
{
    public SkillUpdateValidator()
    {
        RuleFor(skill => skill.Name)
            .MaximumLength(50);
    }
}
