using Application.Dtos;
using Application.Services.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Common.BaseController;

namespace Web.Controllers
{
    [Route("api/videos")]
    [ApiController]
    [Authorize]
    public class VideoController : BaseController
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Video>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVideos()
        {
            var result = await _videoService.GetAllAsync();

            return NewResponse(result);
        }

        [HttpGet("{videoId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Video))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticle(int videoId)
        {
            var result = await _videoService.GetByIdAsync(videoId);

            return NewResponse(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateArticle(
            [FromBody] CreateVideoDto dto,
            IValidator<CreateVideoDto> validator
        )
        {
            var validationResult = validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                return ValidationError(validationResult);
            }

            var result = await _videoService.CreateAsync(dto);

            return NewResponse(result);
        }

        [HttpPatch("{videoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateVideo(
            int videoId,
            [FromBody] UpdateVideoDto dto,
            IValidator<UpdateVideoDto> validator
        )
        {
            var validationResult = validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                return ValidationError(validationResult);
            }

            var result = await _videoService.UpdateAsync(videoId, dto);

            return NewResponse(result);
        }

        [HttpDelete("{videoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteVideo(int videoId)
        {
            var result = await _videoService.DeleteAsync(videoId);

            return NewResponse(result);
        }
    }
}
