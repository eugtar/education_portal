using System.Text;
using System.Text.Encodings.Web;
using Application.Dtos;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Entities.UserGroup;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;

namespace Web.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        private readonly SignInManager<User> _signInManager;
        private readonly IOptionsMonitor<BearerTokenOptions> _bearerTokenOptions;
        private readonly TimeProvider _timeProvider;

        public AuthController(
            UserManager<User> userManager,
            IEmailService emailService,
            SignInManager<User> signInManager,
            IOptionsMonitor<BearerTokenOptions> bearerTokenOptions,
            TimeProvider timeProvider
        )
        {
            _userManager = userManager;
            _emailService = emailService;
            _signInManager = signInManager;
            _bearerTokenOptions = bearerTokenOptions;
            _timeProvider = timeProvider;
        }

        [HttpPost("signup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignUp(
            [FromBody] SignUpDto dto,
            IValidator<SignUpDto> validator
        )
        {
            var validationResult = validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.First().ToString());
            }

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserName = dto.Email,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(
                    new ValidationProblemDetails(
                        new Dictionary<string, string[]>
                        {
                            { "Registration", result.Errors.Select(e => e.Description).ToArray() }
                        }
                    )
                );
            }

            await SendConfirmationEmailAsync(user);

            return Ok();
        }

        [HttpPost("signin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SignIn(
            [FromBody] SignInDto dto,
            [FromQuery] bool? useCookies,
            [FromQuery] bool? useSessionCookies,
            IValidator<SignInDto> validator
        )
        {
            var validationResult = validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.First().ToString());
            }

            var useCookieScheme = (useCookies == true) || (useSessionCookies == true);

            var isPersistent = (useCookies == true) && (useSessionCookies != true);

            _signInManager.AuthenticationScheme = useCookieScheme
                ? IdentityConstants.ApplicationScheme
                : IdentityConstants.BearerScheme;

            var result = await _signInManager.PasswordSignInAsync(
                dto.Email,
                dto.Password,
                isPersistent,
                lockoutOnFailure: true
            );

            if (!result.Succeeded)
            {
                return Problem(result.ToString(), statusCode: StatusCodes.Status401Unauthorized);
            }

            return Empty;
        }

        [HttpPost("refresh")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> RefreshToken(
            [FromBody] RefreshTokenDto dto,
            IValidator<RefreshTokenDto> validator
        )
        {
            var validationResult = validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.First().ToString());
            }

            var refreshTokenProtector = _bearerTokenOptions.Get(IdentityConstants.BearerScheme).RefreshTokenProtector;

            var refreshTicket = refreshTokenProtector.Unprotect(dto.RefreshToken);

            if (
                refreshTicket?.Properties?.ExpiresUtc is not { } expiresUtc ||
                _timeProvider.GetUtcNow() >= expiresUtc ||
                await _signInManager.ValidateSecurityStampAsync(refreshTicket.Principal) is not User user
            )
            {
                return Unauthorized("Invalid or expired refresh token.");
            }

            var newPrincipal = await _signInManager.CreateUserPrincipalAsync(user);

            return SignIn(newPrincipal, IdentityConstants.BearerScheme);
        }

        [HttpGet("emailconfirmation")]
        public async Task<IActionResult> EmailConfirmation(
            [FromQuery] string token,
            [FromQuery] string email,
            [FromQuery] string? changedEmail
        )
        {
            if (await _userManager.FindByEmailAsync(email) is not User user)
            {
                return Unauthorized();
            }

            try
            {
                token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            }
            catch (FormatException)
            {
                return Unauthorized();
            }

            IdentityResult result;

            if (string.IsNullOrEmpty(changedEmail))
            {
                result = await _userManager.ConfirmEmailAsync(user, token);
            }
            else
            {
                result = await _userManager.ChangeEmailAsync(user, changedEmail, token);

                if (result.Succeeded)
                {
                    result = await _userManager.SetUserNameAsync(user, changedEmail);
                }
            }

            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            return Content("Thank you for confirming your email.");
        }

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword(
            [FromBody] ForgotPasswordDto dto,
            IValidator<ForgotPasswordDto> validator
        )
        {
            var validationResult = validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.First().ToString());
            }

            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user != null && await _userManager.IsEmailConfirmedAsync(user))
            {
                var confirmationLink = await SendPasswordResetConfirmationEmailAsync(user);
                return Ok(new { link = confirmationLink });
            }

            return Ok();
        }

        [HttpPost("passwordreset")]
        public async Task<IActionResult> PasswordReset(
            [FromBody] PasswordResetDto dto,
            IValidator<PasswordResetDto> validator
        )
        {
            var validationResult = validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.First().ToString());
            }

            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null || !await _userManager.IsEmailConfirmedAsync(user))
            {
                return BadRequest(
                    IdentityResult.Failed(
                        _userManager.ErrorDescriber.InvalidToken()
                    ).Errors.First()
                );
            }

            IdentityResult result;
            try
            {
                var token = Encoding.UTF8.GetString(
                    WebEncoders.Base64UrlDecode(dto.ConfirmationToken)
                );

                result = await _userManager.ResetPasswordAsync(user, token, dto.Password);
            }
            catch (FormatException)
            {
                result = IdentityResult.Failed(_userManager.ErrorDescriber.InvalidToken());
            }

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.First());
            }

            return Ok();
        }

        private async Task<string?> SendPasswordResetConfirmationEmailAsync(User user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            token = WebEncoders.Base64UrlEncode(
                Encoding.UTF8.GetBytes(token)
            );

            var confirmationMessage = EmailMessage.ForgotPasswordMessage(user.Email!, HtmlEncoder.Default.Encode(token), user.FirstName!);

            await _emailService.SendEmailAsync(
                confirmationMessage.Email,
                confirmationMessage.Subject,
                confirmationMessage.Message
            );

            return HtmlEncoder.Default.Encode(token);
        }

        private async Task SendConfirmationEmailAsync(User user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            token = WebEncoders.Base64UrlEncode(
                Encoding.UTF8.GetBytes(token)
            );

            var queryPair = new RouteValueDictionary()
            {
                ["token"] = token,
                ["email"] = user.Email,
            };

            var confirmationLink = Url.Action(
                "EmailConfirmation",
                "Auth",
                queryPair,
                Request.Scheme
            );

            var confirmationMessage = EmailMessage.EmailConfirmationMessage(user.Email!, confirmationLink!);

            await _emailService.SendEmailAsync(
                confirmationMessage.Email,
                confirmationMessage.Subject,
                confirmationMessage.Message
            );
        }
    }
}