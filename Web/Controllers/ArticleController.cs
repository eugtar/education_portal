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
        public IActionResult GetArticles()
        {
            var articles = _articleService.GetAll();

            return articles.Count == 0 ? NotFound() : !ModelState.IsValid ? BadRequest(ModelState) : Ok(articles);
        }

        [HttpGet("{articleId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ArticleVM))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetArticle(int articleId)
        {
            var article = _articleService.GetById(articleId);

            return article is null ? NotFound() : !ModelState.IsValid ? BadRequest(ModelState) : Ok(article);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateArticle([FromBody] CreateArticleDto createArticleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _articleService.Create(createArticleDto);

            return Created();
        }

        [HttpPatch("{articleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateArticle(int articleId, [FromBody] UpdateArticleDto updateArticleDto)
        {
            _articleService.Update(articleId, updateArticleDto);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }

        [HttpDelete("{articleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult DeleteArticle(int articleId)
        {
            _articleService.Delete(articleId);
            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }

    }
}
