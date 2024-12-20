using Application.Dtos.ArticleDtos;
using FluentValidation;

namespace Application.Validators.ArticleValidators;

public sealed class ArticleCreateValidator : AbstractValidator<CreateArticleDto>
{
    public ArticleCreateValidator()
    {
        RuleFor(article => article.Title)
            .MaximumLength(150)
            .NotEmpty().WithMessage("Title is required");
        RuleFor(article => article.Link)
            .MaximumLength(150)
            .Must(
                link => Uri.IsWellFormedUriString(link, UriKind.RelativeOrAbsolute)
            ).WithMessage("Incorrect link format")
            .NotEmpty().WithMessage("Link is required");
    }
}
