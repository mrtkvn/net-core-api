using Microsoft.AspNetCore.Http;

namespace NetCore.Dto.Logic
{
    public class RequestResult
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public bool IsSuccess => StatusCode == StatusCodes.Status200OK;

        public RequestResult() { StatusCode = StatusCodes.Status200OK; }

        public RequestResult(int statusCode)
        {
            StatusCode = statusCode;
        }

        public RequestResult Error(string message)
        {
            return new RequestResult { StatusCode = StatusCodes.Status400BadRequest, Message = message };
        }

        public RequestResult NotFound(string message = null)
        {
            return new RequestResult { StatusCode = StatusCodes.Status404NotFound, Message = message };
        }

        public RequestResult Unauthorized(string message = null)
        {
            return new RequestResult { StatusCode = StatusCodes.Status401Unauthorized, Message = message };
        }

        public virtual RequestResult ServerError(string message)
        {
            return new RequestResult { StatusCode = StatusCodes.Status500InternalServerError, Message = message };
        }

        public RequestResult FromResult(RequestResult result)
        {
            return new RequestResult { StatusCode = result.StatusCode, Message = result.Message };
        }
    }

    public class RequestResult<T> : RequestResult
    {
        public T Obj { get; set; }

        public RequestResult() { }

        public RequestResult(int statusCode) : base(statusCode) { }

        public new RequestResult<T> Error(string message)
        {
            return new RequestResult<T> { StatusCode = StatusCodes.Status400BadRequest, Message = message };
        }

        public new RequestResult<T> NotFound(string message = null)
        {
            return new RequestResult<T> { StatusCode = StatusCodes.Status404NotFound, Message = message };
        }

        public new RequestResult<T> Unauthorized(string message = null)
        {
            return new RequestResult<T> { StatusCode = StatusCodes.Status401Unauthorized, Message = message };
        }

        public new RequestResult<T> ServerError(string message)
        {
            return new RequestResult<T> { StatusCode = StatusCodes.Status500InternalServerError, Message = message };
        }

        public new RequestResult<T> FromResult(RequestResult result)
        {
            return new RequestResult<T> { StatusCode = result.StatusCode, Message = result.Message };
        }
    }
}
