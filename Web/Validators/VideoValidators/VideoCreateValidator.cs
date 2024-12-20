using Application.Dtos.VideoDtos;
using FluentValidation;
using Web.Validators.RuleBuilderExtensions;

namespace Application.Validators.VideoValidators;

public sealed class VideoCreateValidator : AbstractValidator<CreateVideoDto>
{
    public VideoCreateValidator()
    {
        RuleFor(video => video.Title)
            .MaximumLength(150)
            .NotEmpty().WithMessage("Title is required");
        RuleFor(video => video.Duration)
            .MustBeTimeOfFormat("HH:mm:ss").WithMessage("Duration is not in the correct format('hh:mm:ss')")
            .NotEmpty().WithMessage("Duration is required");
        RuleFor(video => video.QualityId)
            .IsInEnum()
            .NotEmpty().WithMessage("Video quality is required");
    }
}
