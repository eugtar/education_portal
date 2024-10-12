using Application.Dtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CourseVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseService.GetAllAsync();
            return courses.Count == 0 ? NotFound() : !ModelState.IsValid ? BadRequest(ModelState) : Ok(courses);
        }

        [HttpGet("{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CourseVM))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCourse(int courseId)
        {
            var course = await _courseService.GetByIdAsync(courseId);

            return course is null ? NotFound() : !ModelState.IsValid ? BadRequest() : Ok(course);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDto createCourseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _courseService.CreateAsync(createCourseDto);

            return Created();
        }

        [HttpPatch("{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCourse(int courseId, [FromBody] UpdateCourseDto updateCourseDto)
        {
            await _courseService.UpdateAsync(courseId, updateCourseDto);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }

        [HttpDelete("{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            await _courseService.DeleteAsync(courseId);
            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }
    }
}
