namespace Application.Results;

public sealed record Error(string Code, string Message)
{
    public static Error None => new(string.Empty, string.Empty);
    public static Error Null => new("Null", "The specified result value is null");
}
