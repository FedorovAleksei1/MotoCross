using Microsoft.AspNetCore.Builder;

namespace Questionary.Web.Middlewares
{
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
