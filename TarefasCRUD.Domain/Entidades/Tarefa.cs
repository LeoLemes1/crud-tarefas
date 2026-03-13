namespace TarefasCRUD.Domain.Entidades;

public class Tarefa
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Titulo { get; set; }
    public required string Descricao { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}
