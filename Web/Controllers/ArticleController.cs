using Application.Dtos;
using Application.Services.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Common.BaseController;

namespace Web.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticleController : BaseController
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Article>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticles()
        {
            var result = await _articleService.GetAllAsync();

            return NewResponse(result);
        }

        [HttpGet("{articleId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Article))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticle(int articleId)
        {
            var result = await _articleService.GetByIdAsync(articleId);

            return NewResponse(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateArticle(
            [FromBody] CreateArticleDto dto,
            IValidator<CreateArticleDto> validator
        )
        {
            var validationResult = validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                return ValidationError(validationResult);
            }

            var result = await _articleService.CreateAsync(dto);

            return NewResponse(result);
        }

        [HttpPatch("{articleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateArticle(
            int articleId,
            [FromBody] UpdateArticleDto dto,
            IValidator<UpdateArticleDto> validator
        )
        {
            var validationResult = validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                return ValidationError(validationResult);
            }

            var result = await _articleService.UpdateAsync(articleId, dto);

            return NewResponse(result);
        }

        [HttpDelete("{articleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteArticle(int articleId)
        {
            var result = await _articleService.DeleteAsync(articleId);

            return NewResponse(result);
        }
    }
}
