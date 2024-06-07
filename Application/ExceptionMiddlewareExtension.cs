using Microsoft.AspNetCore.Builder;
using Application.General;

namespace Application
{
    public static class ExceptionMiddlewareExtension
    {
        public static void UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionExtension>();
        }
    }
}
