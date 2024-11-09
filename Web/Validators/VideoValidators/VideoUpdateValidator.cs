using Application.Dtos;
using FluentValidation;
using Web.Validators.RuleBuilderExtensions;

namespace Application.Validators.VideoValidators;

public class VideoUpdateValidator : AbstractValidator<UpdateVideoDto>
{
    public VideoUpdateValidator()
    {
        RuleFor(video => video.Title)
            .MaximumLength(150);
        RuleFor(video => video.Duration)
            .MustBeTimeOfFormat("HH:mm:ss").WithMessage("Duration is not in the correct format('hh:mm:ss')");
        RuleFor(video => video.QualityId)
            .IsInEnum();
    }
}
