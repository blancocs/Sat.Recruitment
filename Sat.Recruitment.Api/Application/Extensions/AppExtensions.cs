using Microsoft.AspNetCore.Builder;
using Sat.Recruitment.Api.Application.Middlewares;

namespace Sat.Recruitment.Api.Application.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHanlderMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
