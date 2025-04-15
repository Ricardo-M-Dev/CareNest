using Microsoft.Extensions.Logging;

namespace Application.Common.Results
{
    public class Result
    {
        public bool IsSuccess { get; protected set; }
        public string? Error { get; protected set; }

        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess, string? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, null);

        public static Result Failure(string error) => new(false, error);

        public static Result From(Action action, ILogger? logger = null)
        {
            try
            {
                action();
                return Success();
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Um erro ocorreu durante Result.From()");
                return Failure(ex.Message);
            }
        }

        public static async Task<Result> FromAsync(Func<Task> action, ILogger? logger = null)
        {
            try
            {
                await action();
                return Success();
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Um erro ocorreu durante Result.FromAsync()");
                return Failure(ex.Message);
            }
        }
    }

    public class Result<T> : Result
    {
        public T? Value { get; private set; }

        private Result(bool isSuccess, T? value, string? error)
            : base(isSuccess, error)
        {
            Value = value;
        }

        public static Result<T> Success(T value) => new(true, value, null);

        public static new Result<T> Failure(string error) => new(false, default, error);

        public static Result<T> From(Func<T> func, ILogger? logger = null)
        {
            try
            {
                var value = func();
                return Success(value);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Um erro ocorreu durante Result<T>.From()");
                return Failure(ex.Message);
            }
        }

        public static async Task<Result<T>> FromAsync(Func<Task<T>> func, ILogger? logger = null)
        {
            try
            {
                var value = await func();
                return Success(value);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Um erro ocorreu durante Result<T>.FromAsync()");
                return Failure(ex.Message);
            }
        }
    }
}
