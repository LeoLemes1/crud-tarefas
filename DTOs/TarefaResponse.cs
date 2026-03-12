namespace TarefasCRUD.DTOs
{
    public class TarefaResponse
    {
        public Guid Id { get; set; }
        public required string Titulo { get; set; }
        public required string Descricao { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
