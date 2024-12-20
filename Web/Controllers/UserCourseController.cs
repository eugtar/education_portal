using Application.Dtos.UserDtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Common.BaseController;

namespace Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize(Roles = "student, teacher, administrator")]
    public class UserCourseController : BaseController
    {
        private readonly ICourseService _courseService;

        public UserCourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("{userId}/courses")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserCourseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUserCourses(int userId)
        {
            var result = await _courseService.GetAllUserCoursesAsync(userId);

            return NewResponse(result);
        }

        [HttpGet("{userId}/courses/{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserCourseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUserCourse(int userId, int courseId)
        {
            var result = await _courseService.GetUserCourseInfoAsync(userId, courseId);

            return NewResponse(result);
        }

        [HttpPost("{userId}/courses/{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SubscribeToCourse(int userId, int courseId)
        {
            var result = await _courseService.SubscribeToCourseAsync(userId, courseId);

            return NewResponse(result);
        }

        [HttpPatch("{userId}/courses/{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> StudyTheCourse(int userId, int courseId)
        {
            var result = await _courseService.StudyTheCourseAsync(userId, courseId);

            return NewResponse(result);
        }

        [HttpDelete("{userId}/courses/{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UnsubscribeFromCourse(int userId, int courseId)
        {
            var result = await _courseService.UnsubscribeFromCourseAsync(userId, courseId);

            return NewResponse(result);
        }
    }
}
