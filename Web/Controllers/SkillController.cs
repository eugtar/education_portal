using Application.Dtos.SkillDtos;
using Application.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Common.BaseController;

namespace Web.Controllers
{
    [Route("api/skills")]
    [ApiController]
    [Authorize]
    public class SkillController : BaseController
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SkillDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetSkills()
        {
            var result = await _skillService.GetAllAsync();

            return NewResponse(result);
        }

        [HttpGet("{skillId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SkillDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetSkill(int skillId)
        {
            var result = await _skillService.GetByIdAsync(skillId);

            return NewResponse(result);
        }

        [HttpPost]
        [Authorize(Roles = "teacher, administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        [Authorize(Roles = "teacher, administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        [Authorize(Roles = "teacher, administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> DeleteSkill(int skillId)
        {
            var result = await _skillService.DeleteAsync(skillId);

            return NewResponse(result);
        }
    }
}
