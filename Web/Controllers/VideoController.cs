using Application.Dtos;
using Application.Services.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Web.ControllerBaseExtension;

namespace Web.Controllers
{
    [Route("api/videos")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Video>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetVideos()
        {
            var result = await _videoService.GetAllAsync();

            return this.ResponseResult(result);
        }

        [HttpGet("{videoId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Video))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetArticle(int videoId)
        {
            var result = await _videoService.GetByIdAsync(videoId);

            return this.ResponseResult(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateArticle([FromBody] CreateVideoDto dto, IValidator<CreateVideoDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            var result = await _videoService.CreateAsync(dto);

            return this.ResponseResult(result);
        }

        [HttpPatch("{videoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVideo(int videoId, [FromBody] UpdateVideoDto dto, IValidator<UpdateVideoDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            var result = await _videoService.UpdateAsync(videoId, dto);

            return this.ResponseResult(result);
        }

        [HttpDelete("{videoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteVideo(int videoId)
        {
            var result = await _videoService.DeleteAsync(videoId);

            return this.ResponseResult(result);
        }
    }
}
