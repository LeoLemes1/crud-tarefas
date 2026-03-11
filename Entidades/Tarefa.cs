namespace TarefasCRUD.Entidades
{
    public class Tarefa
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime CriacaoAt { get; set; } = DateTime.UtcNow;
    }
}