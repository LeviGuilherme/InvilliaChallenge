using Invillia.Challenge.CrossCutting.Common.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Invillia.Challenge.CrossCutting.Common.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
