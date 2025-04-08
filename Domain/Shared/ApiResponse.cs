using System.Net;

namespace Domain.Shared;

public class ApiResponse<T>
{
    public string Message { get; set; } = string.Empty;
    public HttpStatusCode StatusCode { get; set; }
    public T? Data { get; set; }
    public bool Success { get; set; }

    public static ApiResponse<T> Ok(T data, string message = "", HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new ApiResponse<T>
        {
            Data = data,
            Message = message,
            StatusCode = statusCode,
            Success = true
        };
    }
    public static ApiResponse<T> Fail(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new ApiResponse<T>
        {
            Message = message,
            StatusCode = statusCode,
            Success = false
        };

    }
}
