using Application.Dtos;
using Application.Services.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Web.ControllerBaseExtension;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Skill>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSkills()
        {
            var result = await _skillService.GetAllAsync();

            return this.ResponseResult(result);
        }

        [HttpGet("{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Skill))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSkill(int skillId)
        {
            var result = await _skillService.GetByIdAsync(skillId);

            return this.ResponseResult(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSkill([FromBody] CreateSkillDto dto, IValidator<CreateSkillDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            var result = await _skillService.CreateAsync(dto);

            return this.ResponseResult(result);
        }

        [HttpPatch("{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSkill(int skillId, [FromBody] UpdateSkillDto dto, IValidator<UpdateSkillDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            var result = await _skillService.UpdateAsync(skillId, dto);

            return this.ResponseResult(result);
        }

        [HttpDelete("{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteSkill(int skillId)
        {
            var result = await _skillService.DeleteAsync(skillId);

            return this.ResponseResult(result);
        }
    }
}
