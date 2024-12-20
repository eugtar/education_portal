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
    public class UserSkillController : BaseController
    {
        private readonly ISkillService _skillService;

        public UserSkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet("{userId}/skills")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserSkillDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUserSkills(int userId)
        {
            var result = await _skillService.GetAllUserSkillsAsync(userId);

            return NewResponse(result);
        }

        [HttpGet("{userId}/skills/{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserSkillDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUserSkill(int userId, int skillId)
        {
            var result = await _skillService.GetUserSkillInfoAsync(userId, skillId);

            return NewResponse(result);
        }
    }
}
