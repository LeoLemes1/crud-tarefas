using TarefasCRUD.Data;
using TarefasCRUD.Entidades;
using TarefasCRUD.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TarefasCRUD.Repositorios;

public class RepositorioTarefa : IRepositorioTarefa

{
    private readonly TarefaDbContext _context;

    public RepositorioTarefa(TarefaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Tarefa>> BuscarTodosAsTarefasAsync() =>
     await _context.Tarefas.ToListAsync();

    public async Task<Tarefa?> BuscarTarefaPorIdAsync(Guid id) =>
        await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);


    public async Task<Tarefa> CriarTarefaAsync(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();
        return tarefa;
    }

    public Task<Tarefa?> EditarTarefaAsync(Guid id, string titulo, string descricao)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExcluirTarefaAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
