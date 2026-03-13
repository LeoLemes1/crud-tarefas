using TarefasCRUD.Application.DTOs;
using TarefasCRUD.Domain.Interfaces;

namespace TarefasCRUD.Application.Handlers.AtualizarTarefa;

public class AtualizarTarefaHandler
{
    private readonly IRepositorioTarefa _repositorioTarefa;

    public AtualizarTarefaHandler(IRepositorioTarefa repositorio)
    {
        _repositorioTarefa = repositorio;
    }

    public async Task<TarefaResponse?> Handle(Guid id, TarefaRequest? request)
    {
        if (request == null || (string.IsNullOrWhiteSpace(request.Titulo) && string.IsNullOrWhiteSpace(request.Descricao)))
            return null;

        var tarefaExistente = await _repositorioTarefa.BuscarTarefaPorIdAsync(id);

        if (tarefaExistente == null)
            return null;

        var titulo = string.IsNullOrWhiteSpace(request.Titulo)
            ? tarefaExistente.Titulo
            : request.Titulo.Trim();

        var descricao = string.IsNullOrWhiteSpace(request.Descricao)
            ? tarefaExistente.Descricao
            : request.Descricao.Trim();

        var tarefa = await _repositorioTarefa.EditarTarefaAsync(id, titulo, descricao);

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
