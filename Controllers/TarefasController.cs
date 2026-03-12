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

        public TarefasController(RepositorioTarefa RepositorioTarefa)
        {
            _RepositorioTarefa = RepositorioTarefa;
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
            var tarefa = await _RepositorioTarefa.FirstOrDefaultAsync(x => x.Id == id);
            if (tarefa == null)
                return NotFound("Tarefa nao encontrada");

            tarefa.Titulo = request.Titulo;
            tarefa.Descricao = request.Descricao;
            await _RepositorioTarefa.SaveChangesAsync();

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
            var tarefa = await _RepositorioTarefa.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
            if (tarefa == null)
                return NotFound("Tarefa nao encontrada");

            _RepositorioTarefa.Tarefas.Remove(tarefa);
            await _RepositorioTarefa.SaveChangesAsync();
            return NoContent();
        }
    }
}
