using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Invillia.Challenge.CrossCutting.Common.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<Exception> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<Exception> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BaseException ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandlerExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandlerExceptionAsync(httpContext, ex);
            }
        }

        private Task HandlerExceptionAsync(HttpContext context, BaseException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            return HandlerAsync(context, ex.Message);
        }

        private Task HandlerExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            return HandlerAsync(context, ex.Message);
        }

        private Task HandlerAsync(HttpContext context, string message)
        {
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
