namespace test_codereview.Application.Models;

public class Result<T>
{
    private Result(bool isSuccess, Error error, T? data = default)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        Data = data;
        IsSuccess = isSuccess;
        Error = error;
    }

    public T? Data { get; }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    public static Result<T> Success(T? data) => new(true, Error.None, data);

    public static Result<T> Failure(Error error) => new(false, error);
}
