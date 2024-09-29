using Application.Dtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserCourseController : ControllerBase
    {
        private readonly IUserCourseService _userCourseService;

        public UserCourseController(IUserCourseService userCourseService)
        {
            _userCourseService = userCourseService;
        }

        [HttpGet("{userId}/courses")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserCourseVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUserCourses(int userId)
        {
            var userCourses = _userCourseService.GetAll(userId);

            return userCourses.Count == 0 ? NotFound() : !ModelState.IsValid ? BadRequest(ModelState) : Ok(userCourses);
        }

        [HttpGet("{userId}/courses/{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserCourseVM))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUserCourse(int userId, int courseId)
        {
            var userCourse = _userCourseService.GetById(userId, courseId);

            return userCourse is null ? NotFound() : !ModelState.IsValid ? BadRequest() : Ok(userCourse);
        }

        [HttpPost("{userId}/courses")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateUserCourse([FromBody] int userId, int courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userCourseService.Create(userId, courseId);

            return Created();
        }

        [HttpPatch("{userId}/courses/{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateUserCourse(int userId, int courseId, [FromBody] UpdateUserCourseDto updateUserCourseDto)
        {
            _userCourseService.Update(userId, courseId, updateUserCourseDto);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }

        [HttpDelete("{userId}/courses/{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult DeleteUserCourse(int userId, int courseId)
        {
            _userCourseService.Delete(userId, courseId);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }
    }
}
