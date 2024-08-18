using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProjects.Api.Modules.GlobalException;

namespace TaskProjects.Api.Modules.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}