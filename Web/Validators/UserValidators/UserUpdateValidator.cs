using Application.Dtos;
using FluentValidation;

namespace Application.Validators.UserValidators;

public class UserUpdateValidator : AbstractValidator<UpdateUserDto>
{
    public UserUpdateValidator()
    {
        RuleFor(user => user.FirstName)
            .MaximumLength(50);
        RuleFor(user => user.LastName)
            .MaximumLength(50);
        RuleFor(user => user.Email)
            .MaximumLength(50)
            .EmailAddress();
        RuleFor(user => user.Password)
            .MinimumLength(8)
            .MaximumLength(16)
            .NotEmpty().WithMessage("Password is required");
        RuleFor(user => user.PasswordConfirmation)
            .Equal(user => user.Password)
            .NotEmpty().WithMessage("Confirm your password");
    }
}
