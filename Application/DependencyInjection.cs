using Application.Interfaces;
using Application.Mapping;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Add application services here
            services.AddScoped<ITodoService,TodoService>();
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
