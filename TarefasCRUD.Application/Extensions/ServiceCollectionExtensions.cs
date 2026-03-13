using Microsoft.Extensions.DependencyInjection;
using TarefasCRUD.Application.Handlers.AtualizarTarefa;
using TarefasCRUD.Application.Handlers.BuscarTarefaPorId;
using TarefasCRUD.Application.Handlers.BuscarTodasAsTarefas;
using TarefasCRUD.Application.Handlers.CriarTarefa;
using TarefasCRUD.Application.Handlers.DeletarTarefa;

namespace TarefasCRUD.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<AtualizarTarefaHandler>();
        services.AddScoped<BuscarTarefaPorIdHandler>();
        services.AddScoped<BuscarTodasAsTarefasHandler>();
        services.AddScoped<CriarTarefaHandler>();
        services.AddScoped<DeletarTarefaHandler>();

        return services;
    }
}
