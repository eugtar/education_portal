using Application.Dtos.EbookDtos;
using Application.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Common.BaseController;


namespace Web.Controllers
{
    [Route("api/ebooks")]
    [ApiController]
    [Authorize]
    public class EbookController : BaseController
    {
        private readonly IEbookService _ebookService;

        public EbookController(IEbookService ebookService)
        {
            _ebookService = ebookService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EbookDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetEbooks()
        {
            var result = await _ebookService.GetAllAsync();

            return NewResponse(result);
        }

        [HttpGet("{ebookId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EbookDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetEbook(int ebookId)
        {
            var result = await _ebookService.GetByIdAsync(ebookId);

            return NewResponse(result);
        }

        [HttpPost]
        [Authorize(Roles = "teacher, administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateEbook(
            [FromBody] CreateEbookDto dto,
            IValidator<CreateEbookDto> validator
        )
        {
            var validationResult = validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                return ValidationError(validationResult);
            }

            var result = await _ebookService.CreateAsync(dto);

            return NewResponse(result);
        }

        [HttpPatch("{ebookId}")]
        [Authorize(Roles = "teacher, administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateCourse(
            int ebookId,
            [FromBody] UpdateEbookDto dto,
            IValidator<UpdateEbookDto> validator
        )
        {
            var validationResult = validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                return ValidationError(validationResult);
            }

            var result = await _ebookService.UpdateAsync(ebookId, dto);

            return NewResponse(result);
        }

        [HttpDelete("{ebookId}")]
        [Authorize(Roles = "teacher, administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> DeleteCourse(int ebookId)
        {
            var result = await _ebookService.DeleteAsync(ebookId);

            return NewResponse(result);
        }
    }
}
