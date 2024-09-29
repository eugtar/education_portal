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
        public IActionResult GetVideos()
        {
            var videos = _videoService.GetAll();

            return videos.Count == 0 ? NotFound() : !ModelState.IsValid ? BadRequest(ModelState) : Ok(videos);
        }

        [HttpGet("{videoId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VideoVM))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetArticle(int videoId)
        {
            var video = _videoService.GetById(videoId);

            return video is null ? NotFound() : !ModelState.IsValid ? BadRequest() : Ok(video);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateArticle([FromBody] CreateVideoDto createVideoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _videoService.Create(createVideoDto);

            return Created();
        }

        [HttpPatch("{videoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateVideo(int videoId, [FromBody] UpdateVideoDto updateVideoDto)
        {
            _videoService.Update(videoId, updateVideoDto);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }

        [HttpDelete("{videoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult DeleteVideo(int videoId)
        {
            _videoService.Delete(videoId);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }
    }
}
