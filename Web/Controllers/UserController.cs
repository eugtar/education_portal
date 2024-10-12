using Application.Dtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserCourseService _userCourseService;
        private readonly IUserSkillService _userSkillService;

        public UserController(IUserService userService, IUserCourseService userCourseService, IUserSkillService userSkillService)
        {
            _userService = userService;
            _userCourseService = userCourseService;
            _userSkillService = userSkillService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllAsync();

            return users.Count == 0 ? NotFound() : !ModelState.IsValid ? BadRequest(ModelState) : Ok(users);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ArticleVM))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser(int userId)
        {
            var user = await _userService.GetByIdAsync(userId);

            return user is null ? NotFound() : !ModelState.IsValid ? BadRequest() : Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userService.CreateAsync(createUserDto);

            return Created();
        }

        [HttpPatch("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] UpdateUserDto updateUserDto)
        {
            await _userService.UpdateAsync(userId, updateUserDto);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _userService.DeleteAsync(userId);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }

        // UserCourse
        [HttpGet("{userId}/courses")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserCourseVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserCourses(int userId)
        {
            var userCourses = await _userCourseService.GetAllAsync(userId);

            return userCourses.Count == 0 ? NotFound() : !ModelState.IsValid ? BadRequest(ModelState) : Ok(userCourses);
        }

        [HttpGet("{userId}/courses/{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserCourseVM))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserCourse(int userId, int courseId)
        {
            var userCourse = await _userCourseService.GetByIdAsync(userId, courseId);

            return userCourse is null ? NotFound() : !ModelState.IsValid ? BadRequest() : Ok(userCourse);
        }

        [HttpPost("{userId}/courses")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUserCourse([FromBody] int userId, int courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userCourseService.CreateAsync(userId, courseId);

            return Created();
        }

        [HttpPatch("{userId}/courses/{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUserCourse(int userId, int courseId, [FromBody] UpdateUserCourseDto updateUserCourseDto)
        {
            await _userCourseService.UpdateAsync(userId, courseId, updateUserCourseDto);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }

        [HttpDelete("{userId}/courses/{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteUserCourse(int userId, int courseId)
        {
            await _userCourseService.DeleteAsync(userId, courseId);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }

        // UserSkill
        [HttpGet("{userId}/skills")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserSkillVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserSkills(int userId)
        {
            var userSkills = await _userSkillService.GetAllAsync(userId);

            return userSkills.Count == 0 ? NotFound() : !ModelState.IsValid ? BadRequest(ModelState) : Ok(userSkills);
        }

        [HttpGet("{userId}/skills/{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserSkillVM))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserSkill(int userId, int skillId)
        {
            var userSkill = await _userSkillService.GetByIdAsync(userId, skillId);

            return userSkill is null ? NotFound() : !ModelState.IsValid ? BadRequest() : Ok(userSkill);
        }

        [HttpPost("{userId}/skills")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUserSkill([FromBody] int userId, int skillId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userSkillService.CreateAsync(userId, skillId);

            return Created();
        }

        [HttpPatch("{userId}/skills/{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUserSkill(int userId, int skillId, [FromBody] UpdateUserSkillDto updateUserSkillDto)
        {
            await _userSkillService.UpdateAsync(userId, skillId, skillId);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }

        [HttpDelete("{userId}/skills/{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteUser(int userId, int skillId)
        {
            await _userSkillService.DeleteAsync(userId, skillId);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }
    }
}
