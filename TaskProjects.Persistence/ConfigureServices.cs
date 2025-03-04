using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskProjects.Interfaces.Persistence;
using TaskProjects.Persistence.Context;
using TaskProjects.Persistence.Repositories;

namespace TaskProjects.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnectionString");
            services.AddDbContext<TaskProjectContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddSingleton<DapperContext>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            return services;
        }
    }
}