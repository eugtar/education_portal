using Application.Dtos;
using Application.Services.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Web.ControllerBaseExtension;

namespace Web.Controllers
{
    [Route("api/ebooks")]
    [ApiController]
    public class EbookController : ControllerBase
    {
        private readonly IEbookService _ebookService;

        public EbookController(IEbookService ebookService)
        {
            _ebookService = ebookService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Ebook>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetEbooks()
        {
            var result = await _ebookService.GetAllAsync();

            return this.ResponseResult(result);
        }

        [HttpGet("{ebookId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ebook))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetEbook(int ebookId)
        {
            var result = await _ebookService.GetByIdAsync(ebookId);

            return this.ResponseResult(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEbook([FromBody] CreateEbookDto dto, IValidator<CreateEbookDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            var result = await _ebookService.CreateAsync(dto);

            return this.ResponseResult(result);
        }

        [HttpPatch("{ebookId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCourse(int ebookId, [FromBody] UpdateEbookDto dto, IValidator<UpdateEbookDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            var result = await _ebookService.UpdateAsync(ebookId, dto);

            return this.ResponseResult(result);
        }

        [HttpDelete("{ebookId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteCourse(int ebookId)
        {
            var result = await _ebookService.DeleteAsync(ebookId);

            return this.ResponseResult(result);
        }
    }
}
