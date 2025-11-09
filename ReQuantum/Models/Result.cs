using System.Diagnostics.CodeAnalysis;

namespace ReQuantum.Models;

public record Result(bool IsSuccess, string Message = "")
{
    #region Static Helper
    public static implicit operator Result(FailResult result)
    {
        return new Result(false, result.Message);
    }

    public static FailResult Fail(string message)
    {
        return new FailResult(message);
    }

    public static Result Success(string message = "")
    {
        return new Result(true, message);
    }

    public static Result<T> Success<T>(T value)
    {
        return new Result<T>(true, string.Empty)
        {
            Value = value
        };
    }
    #endregion
}

public record FailResult(string Message);


public record Result<T>(
    [property: MemberNotNullWhen(true, nameof(Result<T>.Value))]
    bool IsSuccess,
    string Message = "")
{
    /// <summary>
    /// 返回的数据
    /// </summary>
    public T? Value { get; init; }

    public static implicit operator Result<T>(FailResult result)
    {
        return new Result<T>(false, result.Message)
        {
            Value = default
        };
    }

    public static implicit operator Result<T>(T value)
        => Result.Success(value);
}
