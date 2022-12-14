using Microsoft.AspNetCore.Builder;

namespace Cashflow.Application.Webapi
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomResponseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomResponseMiddleware>();
        }
    }
}
