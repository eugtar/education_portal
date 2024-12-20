using Application.Dtos.EbookDtos;
using FluentValidation;
using Web.Validators.RuleBuilderExtensions;

namespace Application.Validators.EbookValidators;

public class EbookUpdateValidator : AbstractValidator<UpdateEbookDto>
{
    public EbookUpdateValidator()
    {
        RuleFor(ebook => ebook.Title)
            .MaximumLength(150);
        RuleFor(ebook => ebook.Author)
            .MaximumLength(150);
        RuleFor(ebook => ebook.PageAmount)
            .GreaterThanOrEqualTo(0);
        RuleFor(ebook => ebook.FormatId)
            .IsInEnum();
        RuleFor(ebook => ebook.PublishedOn)
            ?.MustBeDateOfFormat("yyyy").WithMessage("Year is not in the correct format('YYYY')");
    }
}
