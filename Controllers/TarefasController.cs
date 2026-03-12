using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarefasCRUD.Data;
using TarefasCRUD.DTOs;
using TarefasCRUD.Entidades;
using TarefasCRUD.Interfaces;
using TarefasCRUD.Repositorios;

namespace TarefasCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {

        private readonly IRepositorioTarefa _RepositorioTarefa;

        public TarefasController(IRepositorioTarefa repositorioTarefa)
        {
            _RepositorioTarefa = repositorioTarefa;
        }


        [HttpGet]
        public async Task<IActionResult> ListarTodasAsTarefas()
        {
            var tarefas = await _RepositorioTarefa.BuscarTodosAsTarefasAsync();

            var response = tarefas.Select(x => new TarefaResponse
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Descricao = x.Descricao,
                CriadoEm = x.CriadoEm
            }).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarTarefaPorId(Guid id)
        {
            var tarefa = await _RepositorioTarefa.BuscarTarefaPorIdAsync(id);

            if (tarefa == null)
                return NotFound("Tarefa nao encontrada!");

            var response = new TarefaResponse
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                CriadoEm = tarefa.CriadoEm
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CriarTarefa([FromBody] TarefaRequest request)
        {
            var tarefa = new Tarefa
            {
                Titulo = request.Titulo,
                Descricao = request.Descricao
            };
           
            await _RepositorioTarefa.CriarTarefaAsync(tarefa);

            var response = new TarefaResponse
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                CriadoEm = tarefa.CriadoEm
            };
            return Created($"/api/tarefas/{tarefa.Id}", response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarTarefa(Guid id, [FromBody] TarefaRequest request)
        {
            var tarefa = await _RepositorioTarefa.EditarTarefaAsync(id, request.Titulo, request.Descricao);

            if (tarefa == null)
                return NotFound("Tarefa nao encontrada!");

            var response = new TarefaResponse
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                CriadoEm = tarefa.CriadoEm
            };  

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarTarefa(Guid id)
        {
            var deletado = await _RepositorioTarefa.ExcluirTarefaAsync(id);

            if (!deletado)
                return NotFound("Tarefa não encontrada");

            return NoContent();
        }
    }
}
