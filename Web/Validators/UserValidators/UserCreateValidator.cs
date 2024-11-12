using Application.Dtos;
using FluentValidation;

namespace Application.Validators.UserValidators;

public sealed class UserCreateValidator : AbstractValidator<CreateUserDto>
{
    public UserCreateValidator()
    {
        RuleFor(user => user.FirstName)
            .MaximumLength(50)
            .NotEmpty().WithMessage("Name is required");
        RuleFor(user => user.LastName)
            .MaximumLength(50)
            .NotEmpty().WithMessage("Surname is required");
        RuleFor(user => user.Email)
            .MaximumLength(50)
            .EmailAddress()
            .NotEmpty().WithMessage("Email is required");
        RuleFor(user => user.Password)
            .MinimumLength(5)
            .MaximumLength(24)
            .NotEmpty().WithMessage("Password is required");
        RuleFor(user => user.PasswordConfirmation)
            .Equal(user => user.Password)
            .NotEmpty().WithMessage("Confirm your password");
    }
}
