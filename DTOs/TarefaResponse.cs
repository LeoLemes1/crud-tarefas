namespace TarefasCRUD.DTOs
{
    public class TarefaResponse
    {
        public Guid Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
