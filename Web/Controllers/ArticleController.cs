using Application.Dtos;
using Application.Services.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Web.ControllerBaseExtension;

namespace Web.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Article>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetArticles()
        {
            var result = await _articleService.GetAllAsync();

            return this.ResponseResult(result);
        }

        [HttpGet("{articleId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Article))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetArticle(int articleId)
        {
            var result = await _articleService.GetByIdAsync(articleId);

            return this.ResponseResult(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateArticle([FromBody] CreateArticleDto dto, IValidator<CreateArticleDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            var result = await _articleService.CreateAsync(dto);

            return this.ResponseResult(result);
        }

        [HttpPatch("{articleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateArticle(int articleId, [FromBody] UpdateArticleDto dto, IValidator<UpdateArticleDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            var result = await _articleService.UpdateAsync(articleId, dto);

            return this.ResponseResult(result);
        }

        [HttpDelete("{articleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteArticle(int articleId)
        {
            var result = await _articleService.DeleteAsync(articleId);

            return this.ResponseResult(result);
        }

    }
}
