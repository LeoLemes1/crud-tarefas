using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarefasCRUD.Data;
using TarefasCRUD.DTOs;
using TarefasCRUD.Entidades;

namespace TarefasCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {

        private readonly TarefaDbContext _context;

        public TarefasController(TarefaDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> ListarTarefas()
        {
            var tarefas = await _context.Tarefas.ToListAsync();

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
        public async Task<IActionResult> VisualizarTarefa(Guid id)
        {
            var tarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
            if (tarefa == null)
                return NotFound("Tarefa nao encontrada");

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
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

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
            var tarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
            if (tarefa == null)
                return NotFound("Tarefa nao encontrada");

            tarefa.Titulo = request.Titulo;
            tarefa.Descricao = request.Descricao;
            await _context.SaveChangesAsync();

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
            var tarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
            if (tarefa == null)
                return NotFound("Tarefa nao encontrada");

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
