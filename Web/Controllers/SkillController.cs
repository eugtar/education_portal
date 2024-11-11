using Application.Dtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SkillVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSkills()
        {
            var skills = await _skillService.GetAllAsync();

            return skills.Count == 0 ? NotFound() : !ModelState.IsValid ? BadRequest(ModelState) : Ok(skills);
        }

        [HttpGet("{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SkillVM))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSkill(int skillId)
        {
            var skill = await _skillService.GetByIdAsync(skillId);

            return skill is null ? NotFound() : !ModelState.IsValid ? BadRequest() : Ok(skill);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSkill([FromBody] CreateSkillDto createSkillDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _skillService.CreateAsync(createSkillDto);

            return Created();
        }

        [HttpPatch("{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSkill(int skillId, [FromBody] UpdateSkillDto updateSkillDto)
        {
            await _skillService.UpdateAsync(skillId, updateSkillDto);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }

        [HttpDelete("{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteSkill(int skillId)
        {
            await _skillService.DeleteAsync(skillId);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }
    }
}
