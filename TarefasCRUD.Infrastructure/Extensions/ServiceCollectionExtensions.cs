using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TarefasCRUD.Domain.Interfaces;
using TarefasCRUD.Infrastructure.Data;
using TarefasCRUD.Infrastructure.Repositorios;

namespace TarefasCRUD.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TarefaDbContext>(options =>
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("TarefasCRUD.Infrastructure")));

        services.AddScoped<IRepositorioTarefa, RepositorioTarefa>();

        return services;
    }
}
