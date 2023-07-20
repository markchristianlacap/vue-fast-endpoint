namespace Domain.Common;

public sealed class Result<T>
    where T : new()
{
    public T Data { get; } = new();
    public bool IsSuccess { get; }
    public string? Error { get; }

    public Result(bool success, string error)
    {
        IsSuccess = success;
        Error = error;
    }

    public Result(T data)
    {
        Data = data;
        IsSuccess = true;
    }

    public Result(string error)
    {
        IsSuccess = false;
        Error = error;
    }
}
