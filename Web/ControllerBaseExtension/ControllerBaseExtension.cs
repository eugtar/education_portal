using System.Net;
using Application.Results;
using Microsoft.AspNetCore.Mvc;

namespace Web.ControllerBaseExtension;

public static class ControllerBaseExtension
{
    public static IActionResult ResponseResult(this ControllerBase controller, Result result)
    {
        if (result.IsFailure)
        {
            return ResponseError(controller, result);
        }
        else
        {
            return controller.Ok();
        }
    }

    public static IActionResult ResponseResult<T>(this ControllerBase controller, Result<T> result)
    {
        if (result.IsFailure)
        {
            return ResponseError(controller, result);
        }
        else
        {
            return controller.Ok(result.Value);
        }
    }

    private static IActionResult ResponseError(ControllerBase controller, Result result)
    {
        return result.Error.Code switch
        {
            HttpStatusCode.NotFound => controller.NotFound(result.Error.Message),
            HttpStatusCode.BadRequest => controller.BadRequest(result.Error.Message),
            _ => controller.StatusCode(500)
        };
    }
}
