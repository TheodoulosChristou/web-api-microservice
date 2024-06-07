using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Net;

namespace Application.General
{
    public class CustomExceptionExtension
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionExtension> _log;

        public CustomExceptionExtension(RequestDelegate next, ILogger<CustomExceptionExtension> log)
        {
            _log = log;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var ErrorMessage = "";
            var Type = "";
            var Detail = "";

            if (exception is DbUpdateException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                ErrorMessage = "Database update error";
                Type = exception.GetType().ToString();
                Detail = exception.InnerException.Message;

                _log.LogError($"DbUpdateException: {exception.Message}");
                _log.LogError(Type);
                _log.LogError(Detail);
            }
            else if (exception is SqlException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                ErrorMessage = "Database SQL error";
                Type = exception.GetType().ToString();
                Detail = exception.Message;

                _log.LogError($"SqlException: {exception.Message}");
                _log.LogError(Type);
                _log.LogError(Detail);
            }
            else if (exception is InvalidOperationException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                ErrorMessage = "Invalid Operation";
                Type = exception.GetType().ToString();
                Detail = exception.Message;

                _log.LogError($"InvalidOperationException: {exception.Message}");
                _log.LogError(Type);
                _log.LogError(Detail);
            }
            else if (exception is SystemException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                ErrorMessage = "System Exception";
                Type = exception.GetType().ToString();
                Detail = exception.Message;

                _log.LogError($"SystemException: {exception.Message}");
                _log.LogError(Type);
                _log.LogError(Detail);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ErrorMessage = exception.Message;
                Type = exception.GetType().ToString();
                Detail = exception.Message;

                _log.LogError($"CustomException: {exception.Message}");
                _log.LogError(Type);
                _log.LogError(Detail);
            }
            return context.Response.WriteAsync(new ErrorDetails()
            {
                Type = Type,
                Title = ErrorMessage,
                Status = context.Response.StatusCode,
                Detail = Detail
            }.ToString());
        }
    }
}
