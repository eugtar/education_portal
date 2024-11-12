using Application.Dtos;
using Application.Services.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Common.BaseController;

namespace Web.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillController : BaseController
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Skill>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSkills()
        {
            var result = await _skillService.GetAllAsync();

            return NewResponse(result);
        }

        [HttpGet("{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Skill))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSkill(int skillId)
        {
            var result = await _skillService.GetByIdAsync(skillId);

            return NewResponse(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSkill(
            [FromBody] CreateSkillDto dto,
            IValidator<CreateSkillDto> validator
        )
        {
            var validationResult = validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                return ValidationError(validationResult);
            }

            var result = await _skillService.CreateAsync(dto);

            return NewResponse(result);
        }

        [HttpPatch("{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSkill(
            int skillId,
            [FromBody] UpdateSkillDto dto,
            IValidator<UpdateSkillDto> validator
        )
        {
            var validationResult = validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                return ValidationError(validationResult);
            }

            var result = await _skillService.UpdateAsync(skillId, dto);

            return NewResponse(result);
        }

        [HttpDelete("{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteSkill(int skillId)
        {
            var result = await _skillService.DeleteAsync(skillId);

            return NewResponse(result);
        }
    }
}
