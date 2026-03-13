using TarefasCRUD.DTOs;
using TarefasCRUD.Entidades;
using TarefasCRUD.Interfaces;

namespace TarefasCRUD.Handlers.CriarTarefa
{
    public class CriarTarefaHandler
    {
        private readonly IRepositorioTarefa _repositorioTarefa;

        public CriarTarefaHandler(IRepositorioTarefa repositorioTarefa)
        {
            _repositorioTarefa = repositorioTarefa;
        }

        public async Task<TarefaResponse?> Handle(TarefaRequest? request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Titulo) || string.IsNullOrWhiteSpace(request.Descricao))
                return null;

            var tarefa = new Tarefa
            {
                Titulo = request.Titulo!.Trim(),
                Descricao = request.Descricao!.Trim()
            };

            var tarefaCriada = await _repositorioTarefa.CriarTarefaAsync(tarefa);

            return new TarefaResponse
            {
                Id = tarefaCriada.Id,
                Titulo = tarefaCriada.Titulo,
                Descricao = tarefaCriada.Descricao,
                CriadoEm = tarefaCriada.CriadoEm
            };
        }
    }
}
