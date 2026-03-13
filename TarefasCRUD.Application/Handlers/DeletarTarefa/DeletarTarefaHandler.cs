using TarefasCRUD.Domain.Interfaces;

namespace TarefasCRUD.Application.Handlers.DeletarTarefa;

public class DeletarTarefaHandler
{
    private readonly IRepositorioTarefa _repositorioTarefa;

    public DeletarTarefaHandler(IRepositorioTarefa repositorioTarefa)
    {
        _repositorioTarefa = repositorioTarefa;
    }

    public async Task<bool> Handle(Guid id)
    {
        return await _repositorioTarefa.ExcluirTarefaAsync(id);
    }
}
