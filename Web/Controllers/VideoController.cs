using Application.Dtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VideoVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVideos()
        {
            var videos = await _videoService.GetAllAsync();

            return videos.Count == 0 ? NotFound() : !ModelState.IsValid ? BadRequest(ModelState) : Ok(videos);
        }

        [HttpGet("{videoId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VideoVM))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticle(int videoId)
        {
            var video = await _videoService.GetByIdAsync(videoId);

            return video is null ? NotFound() : !ModelState.IsValid ? BadRequest() : Ok(video);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateArticle([FromBody] CreateVideoDto createVideoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _videoService.CreateAsync(createVideoDto);

            return Created();
        }

        [HttpPatch("{videoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateVideo(int videoId, [FromBody] UpdateVideoDto updateVideoDto)
        {
            await _videoService.UpdateAsync(videoId, updateVideoDto);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }

        [HttpDelete("{videoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteVideo(int videoId)
        {
            await _videoService.DeleteAsync(videoId);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }
    }
}
