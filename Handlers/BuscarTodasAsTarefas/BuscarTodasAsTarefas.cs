using TarefasCRUD.DTOs;
using TarefasCRUD.Interfaces;

namespace TarefasCRUD.Handlers.BuscarTodasAsTarefas
{
    public class BuscarTodasAsTarefasHandler
    {
        private readonly IRepositorioTarefa _repositorioTarefa;

        public BuscarTodasAsTarefasHandler(IRepositorioTarefa repositorioTarefa)
        {
            _repositorioTarefa = repositorioTarefa;
        }
        public async Task<List<TarefaResponse>> Handle()
        {
            var tarefas = await _repositorioTarefa.BuscarTodosAsTarefasAsync();

            return tarefas.Select(x => new TarefaResponse
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Descricao = x.Descricao,
                CriadoEm = x.CriadoEm
            }).ToList();
        }
    }
}
