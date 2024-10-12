namespace Application.Results;

public class Result<T> : Result
{
    private readonly T? _value;

    public T Value
    {
        get
        {
            if (_value is not null)
            {
                return _value;
            };

            throw new InvalidOperationException("The value of a failure result can not be accessed.");
        }

        private init
        {
            _value = value;
        }
    }

    protected internal Result(T value, bool isSuccess) : this(isSuccess, Error.None)
    {
        _value = value;
    }

    private Result(bool isSuccess, Error error) : base(isSuccess, error) { }

    public static Result<T> Success(T value)
    {
        return new Result<T>(value, true);
    }

    public static new Result<T> Failure(Error error)
    {
        return new Result<T>(false, error);
    }

    public static implicit operator Result<T>(T value)
    {
        if (value is null)
        {
            return Result<T>.Failure(Error.Null);
        }
        return Result<T>.Success(value);
    }

    public static implicit operator Result<T>(Error error)
    {
        return Result<T>.Failure(error);
    }
}
