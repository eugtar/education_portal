using Application.Dtos;
using Application.Services.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Web.ControllerBaseExtension;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Course>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCourses()
        {
            var result = await _courseService.GetAllAsync();

            return this.ResponseResult(result);
        }

        [HttpGet("{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Course))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCourse(int courseId)
        {
            var result = await _courseService.GetByIdAsync(courseId);

            return this.ResponseResult(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDto dto, IValidator<CreateCourseDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            var result = await _courseService.CreateAsync(dto);

            return this.ResponseResult(result);
        }

        [HttpPatch("{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCourse(int courseId, [FromBody] UpdateCourseDto dto, IValidator<UpdateCourseDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            var result = await _courseService.UpdateAsync(courseId, dto);

            return this.ResponseResult(result);
        }

        [HttpDelete("{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            var result = await _courseService.DeleteAsync(courseId);

            return this.ResponseResult(result);
        }
    }
}
