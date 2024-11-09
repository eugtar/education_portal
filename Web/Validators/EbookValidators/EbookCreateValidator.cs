using Application.Dtos;
using FluentValidation;
using Web.Validators.RuleBuilderExtensions;

namespace Application.Validators.EbookValidators;

public sealed class EbookCreateValidator : AbstractValidator<CreateEbookDto>
{
    public EbookCreateValidator()
    {
        RuleFor(ebook => ebook.Title)
            .MaximumLength(150)
            .NotEmpty().WithMessage("Title is required");
        RuleFor(ebook => ebook.Author)
            .MaximumLength(150)
            .NotEmpty().WithMessage("Title is required");
        RuleFor(ebook => ebook.PageAmount)
            .GreaterThanOrEqualTo(0)
            .NotEmpty().WithMessage("Page amount is required");
        RuleFor(ebook => ebook.FormatId)
            .IsInEnum()
            .NotEmpty().WithMessage("Book format is required");
        RuleFor(ebook => ebook.PublishedOn)
            .MustBeDateTimeOfFormat("yyyy").WithMessage("Year is not in the correct format('YYYY')")
            .NotEmpty().WithMessage("Year of publication is required");
    }
}
