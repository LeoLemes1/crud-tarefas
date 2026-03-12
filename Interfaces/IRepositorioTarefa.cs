using TarefasCRUD.Entidades;

namespace TarefasCRUD.Interfaces;

public interface IRepositorioTarefa
{
    Task<List<Tarefa>> BuscarTodosAsTarefasAsync();
    Task<Tarefa?> BuscarTarefaPorIdAsync(Guid id);
    Task<Tarefa> CriarTarefaAsync(Tarefa tarefa);
    Task<Tarefa> EditarTarefaAsync(Guid id, string titulo, string descricao);
    Task<bool> ExcluirTarefaAsync(Guid id);

}
