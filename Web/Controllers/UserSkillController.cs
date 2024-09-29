using Application.Services.Interfaces;
using Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserSkillController : ControllerBase
    {
        private readonly IUserSkillService _userSkillService;

        public UserSkillController(IUserSkillService userSkillService)
        {
            _userSkillService = userSkillService;
        }

        [HttpGet("{userId}/skills")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserSkillVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUserSkills(int userId)
        {
            var userSkills = _userSkillService.GetAll(userId);

            return userSkills.Count == 0 ? NotFound() : !ModelState.IsValid ? BadRequest(ModelState) : Ok(userSkills);
        }

        [HttpGet("{userId}/skills/{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserSkillVM))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUserSkill(int userId, int skillId)
        {
            var userSkill = _userSkillService.GetById(userId, skillId);

            return userSkill is null ? NotFound() : !ModelState.IsValid ? BadRequest() : Ok(userSkill);
        }

        [HttpPost("{userId}/skills")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateUserSkill([FromBody] int userId, int skillId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userSkillService.Create(userId, skillId);

            return Created();
        }

        [HttpPatch("{userId}/skills/{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateUserSkill(int userId, int skillId, [FromBody] UpdateUserSkillDto updateUserSkillDto)
        {
            _userSkillService.Update(userId, skillId, skillId);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }

        [HttpDelete("{userId}/skills/{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult DeleteUser(int userId, int skillId)
        {
            _userSkillService.Delete(userId, skillId);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }
    }
}
