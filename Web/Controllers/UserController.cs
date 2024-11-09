using Application.Dtos;
using Application.Services.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Web.ControllerBaseExtension;

namespace Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetAllAsync();

            return this.ResponseResult(result);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUser(int userId)
        {
            var result = await _userService.GetByIdAsync(userId);

            return this.ResponseResult(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto, IValidator<CreateUserDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            var result = await _userService.CreateAsync(dto);

            return this.ResponseResult(result);
        }

        [HttpPatch("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] UpdateUserDto dto, IValidator<UpdateUserDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            var result = await _userService.UpdateAsync(userId, dto);

            return this.ResponseResult(result);
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteUser(int userId)
        {
            var result = await _userService.DeleteAsync(userId);

            return this.ResponseResult(result);
        }
    }
}
