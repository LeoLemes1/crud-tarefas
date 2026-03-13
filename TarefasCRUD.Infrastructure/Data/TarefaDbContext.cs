using Microsoft.EntityFrameworkCore;
using TarefasCRUD.Domain.Entidades;
using TarefasCRUD.Infrastructure.Mapping;

namespace TarefasCRUD.Infrastructure.Data;

public class TarefaDbContext : DbContext
{
    public TarefaDbContext(DbContextOptions<TarefaDbContext> options) : base(options)
    {
    }

    public DbSet<Tarefa> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TarefaMap());
    }
}
