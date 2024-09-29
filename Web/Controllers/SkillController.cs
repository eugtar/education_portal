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
        public IActionResult GetSkills()
        {
            var skills = _skillService.GetAll();

            return skills.Count == 0 ? NotFound() : !ModelState.IsValid ? BadRequest(ModelState) : Ok(skills);
        }

        [HttpGet("{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SkillVM))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSkill(int skillId)
        {
            var skill = _skillService.GetById(skillId);

            return skill is null ? NotFound() : !ModelState.IsValid ? BadRequest() : Ok(skill);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateSkill([FromBody] CreateSkillDto createSkillDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _skillService.Create(createSkillDto);

            return Created();
        }

        [HttpPatch("{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateSkill(int skillId, [FromBody] UpdateSkillDto updateSkillDto)
        {
            _skillService.Update(skillId, updateSkillDto);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }

        [HttpDelete("{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult DeleteSkill(int skillId)
        {
            _skillService.Delete(skillId);

            return !ModelState.IsValid ? BadRequest(ModelState) : Ok();
        }
    }
}
