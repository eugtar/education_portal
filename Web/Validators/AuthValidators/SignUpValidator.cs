using Application.Dtos;
using FluentValidation;

namespace Web.Validators.AuthValidators;

public class SignUpValidator : AbstractValidator<SignUpDto>
{
    public SignUpValidator()
    {
        RuleFor(dto => dto.FirstName)
            .NotEmpty().WithMessage("Please, provide your first name")
            .MaximumLength(50);

        RuleFor(dto => dto.LastName)
            .NotEmpty().WithMessage("Please, provide you last name")
            .MaximumLength(50);

        RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage("Email is required")
            .MaximumLength(50)
            .EmailAddress();

        RuleFor(dto => dto.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Your password length must be at least 8")
            .MaximumLength(16).WithMessage("Your password length must not exceed 16")
            .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter")
            .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter")
            .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number")
            .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.)");
    }
}
