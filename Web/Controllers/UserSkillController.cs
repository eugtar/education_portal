using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Web.ControllerBaseExtension;

namespace Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserSkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public UserSkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet("{userId}/skills")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserSkill>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserSkills(int userId)
        {
            var result = await _skillService.GetAllUserSkillsAsync(userId);

            return this.ResponseResult(result);
        }

        [HttpGet("{userId}/skills/{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserSkill))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserSkillInfo(int userId, int skillId)
        {
            var result = await _skillService.GetUserSkillInfoAsync(userId, skillId);

            return this.ResponseResult(result);
        }
    }
}

