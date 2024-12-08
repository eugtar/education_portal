using Application.Dtos;
using FluentValidation;

namespace Web.Validators.AuthValidators;

public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordDto>
{
    public ForgotPasswordValidator()
    {
        RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage("Email is required")
            .MaximumLength(50)
            .EmailAddress();
    }
}
