using Application.Dtos.RoleDtos;
using Application.Services.Interfaces;
using Domain.Enums;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/roles")]
    [ApiController]
    [Authorize(Roles = "administrator")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SetRole(
            [FromBody] SetRoleDto dto,
            IValidator<SetRoleDto> validator
        )
        {
            var validationResult = validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.First().ToString());
            }

            switch (dto.Role)
            {
                case UserRoleEnum.Student:
                    await _roleService.SetAsStudentAsync(dto.User);
                    return Ok();
                case UserRoleEnum.Teacher:
                    await _roleService.SetAsTeacherAsync(dto.User);
                    return Ok();
                case UserRoleEnum.Admin:
                    await _roleService.SetAsAdministratorAsync(dto.User);
                    return Ok();
                default:
                    return BadRequest();
            }
        }
    }
}
