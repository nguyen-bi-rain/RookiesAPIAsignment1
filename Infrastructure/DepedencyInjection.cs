using Domain.Interfaces;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure;

public static class DepedencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ITodoRepository, TodoRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();
        return services;
    }
}
