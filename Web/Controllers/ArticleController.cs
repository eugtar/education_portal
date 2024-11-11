using Application.Dtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ArticleVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticles()
        {
            var articles = await _articleService.GetAllAsync();

            return articles.Count == 0 ? NotFound() : !ModelState.IsValid ? BadRequest(ModelState) : Ok(articles);
        }

        [HttpGet("{articleId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ArticleVM))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticle(int articleId)
        {
            var article = await _articleService.GetByIdAsync(articleId);

            return article is null ? NotFound() : !ModelState.IsValid ? BadRequest(ModelState) : Ok(article);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateArticle([FromBody] CreateArticleDto createArticleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _articleService.CreateAsync(createArticleDto);

            return Created();
        }

        [HttpPatch("{articleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateArticle(int articleId, [FromBody] UpdateArticleDto updateArticleDto)
        {
            await _articleService.UpdateAsync(articleId, updateArticleDto);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }

        [HttpDelete("{articleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteArticle(int articleId)
        {
            await _articleService.DeleteAsync(articleId);
            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }

    }
}
