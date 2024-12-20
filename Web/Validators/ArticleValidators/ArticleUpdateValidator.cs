using Application.Dtos.ArticleDtos;
using FluentValidation;

namespace Application.Validators.ArticleValidators;

public sealed class ArticleUpdateValidator : AbstractValidator<UpdateArticleDto>
{
    public ArticleUpdateValidator()
    {
        RuleFor(article => article.Title)
            .MaximumLength(150);
        RuleFor(article => article.Link)
            .MaximumLength(150)
            .Must(
                link => Uri.IsWellFormedUriString(link, UriKind.RelativeOrAbsolute)
            ).WithMessage("Incorrect link format");
    }
}
