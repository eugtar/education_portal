using Application.Dtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EbookVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEbooks()
        {
            var ebooks = await _ebookService.GetAllAsync();

            return ebooks.Count == 0 ? NotFound() : !ModelState.IsValid ? BadRequest(ModelState) : Ok(ebooks);
        }

        [HttpGet("{ebookId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EbookVM))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEbook(int ebookId)
        {
            var ebook = await _ebookService.GetByIdAsync(ebookId);

            return ebook is null ? NotFound() : !ModelState.IsValid ? BadRequest() : Ok(ebook);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEbook([FromBody] CreateEbookDto createEbookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ebookService.CreateAsync(createEbookDto);

            return Created();
        }

        [HttpPatch("{ebookId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCourse(int ebookId, [FromBody] UpdateEbookDto updateEbookDto)
        {
            await _ebookService.UpdateAsync(ebookId, updateEbookDto);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }

        [HttpDelete("{ebookId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteCourse(int ebookId)
        {
            await _ebookService.DeleteAsync(ebookId);
            
            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }
    }
}
