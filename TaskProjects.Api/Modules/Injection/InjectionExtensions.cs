using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProjects.Api.Modules.GlobalException;

namespace TaskProjects.Api.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<GlobalExceptionHandler>();

            return services;
        }
    }
}