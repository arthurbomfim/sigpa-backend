using Microsoft.Extensions.DependencyInjection;
using SIGPA_Backend.Domain.Interfaces;
using SIGPA_Backend.Infrastructure.Repositories;

namespace SIGPA_Backend.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        return services;
    }
}