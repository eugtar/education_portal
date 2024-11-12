using System.Net;

namespace Application.Results;

public record Error(HttpStatusCode Code, string Message)
{
    public static Error None => new(HttpStatusCode.OK, string.Empty);
    public static Error Null => new(HttpStatusCode.InternalServerError, "Internal server error");
}
