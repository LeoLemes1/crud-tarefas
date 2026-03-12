using TarefasCRUD.Data;
using TarefasCRUD.Entidades;
using TarefasCRUD.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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

  public async Task<Tarefa> EditarTarefaAsync(Guid id, string titulo, string descricao)
{
    var tarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);

    if (tarefa == null)
        return null;

    tarefa.Titulo = titulo;
    tarefa.Descricao = descricao;

    await _context.SaveChangesAsync();

    return tarefa;
}

    public async Task<bool> ExcluirTarefaAsync(Guid id)
    {
        var tarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);

        if (tarefa == null)
            return false;

        _context.Tarefas.Remove(tarefa);

        await _context.SaveChangesAsync();

        return true;
    }
}
