using Application.Dtos;
using Application.Services.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Common.BaseController;

namespace Web.Controllers
{
    [Route("api/courses")]
    [ApiController]
    [Authorize]
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Course>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCourses()
        {
            var result = await _courseService.GetAllAsync();

            return NewResponse(result);
        }

        [HttpGet("{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Course))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCourse(int courseId)
        {
            var result = await _courseService.GetByIdAsync(courseId);

            return NewResponse(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCourse(
            [FromBody] CreateCourseDto dto,
            IValidator<CreateCourseDto> validator
        )
        {
            var validationResult = validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                return ValidationError(validationResult);
            }

            var result = await _courseService.CreateAsync(dto);

            return NewResponse(result);
        }

        [HttpPatch("{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCourse(
            int courseId,
            [FromBody] UpdateCourseDto dto,
            IValidator<UpdateCourseDto> validator
        )
        {
            var validationResult = validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                return ValidationError(validationResult);
            }

            var result = await _courseService.UpdateAsync(courseId, dto);

            return NewResponse(result);
        }

        [HttpDelete("{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            var result = await _courseService.DeleteAsync(courseId);

            return NewResponse(result);
        }
    }
}
