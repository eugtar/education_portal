using System.Net;
using Application.Results;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Common.BaseController
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult NewResponse(Result result)
        {
            if (result.IsFailure)
            {
                return Error(result);
            }
            else
            {
                return base.Ok();
            }
        }

        protected IActionResult NewResponse<T>(Result<T> result)
        {
            if (result.IsFailure)
            {
                return Error(result);
            }
            else
            {
                return base.Ok(result.Value);
            }
        }

        private IActionResult Error(Result result)
        {
            return result.Error.Code switch
            {
                HttpStatusCode.NotFound => base.NotFound(result.Error.Message),
                HttpStatusCode.BadRequest => base.BadRequest(result.Error.Message),
                _ => base.StatusCode(500)
            };
        }

        protected IActionResult ValidationError(ValidationResult result)
        {
            return base.BadRequest(result.Errors.First().ErrorMessage);
        }
    }
}
