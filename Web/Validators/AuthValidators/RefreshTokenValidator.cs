using Application.Dtos.AuthDtos;
using FluentValidation;

namespace Web.Validators.AuthValidators;

public class RefreshTokenValidator : AbstractValidator<RefreshTokenDto>
{
    public RefreshTokenValidator()
    {
        RuleFor(dto => dto.RefreshToken)
            .NotEmpty().WithMessage("RefreshToken is required");
    }
}
