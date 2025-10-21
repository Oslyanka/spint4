using Microsoft.Extensions.DependencyInjection;
using SwaggerSchoolAPI.Repositories;
using SwaggerSchoolAPI.Services;

namespace SwaggerSchoolAPI
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<AlunoService>();
            return services;
        }
    }
}
