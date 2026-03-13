using TarefasCRUD.Application.DTOs;
using TarefasCRUD.Domain.Interfaces;

namespace TarefasCRUD.Application.Handlers.BuscarTarefaPorId;

public class BuscarTarefaPorIdHandler
{
    private readonly IRepositorioTarefa _repositorioTarefa;

    public BuscarTarefaPorIdHandler(IRepositorioTarefa repositorioTarefa)
    {
        _repositorioTarefa = repositorioTarefa;
    }

    public async Task<TarefaResponse?> Handle(Guid id)
    {
        var tarefa = await _repositorioTarefa.BuscarTarefaPorIdAsync(id);

        if (tarefa == null)
            return null;

        return new TarefaResponse
        {
            Id = tarefa.Id,
            Titulo = tarefa.Titulo,
            Descricao = tarefa.Descricao,
            CriadoEm = tarefa.CriadoEm
        };
    }
}
