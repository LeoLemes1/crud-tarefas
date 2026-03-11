using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using TarefasCRUD.Data;
using TarefasCRUD.Entidades;

namespace Controllers.AutControlle
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
            return Ok(tarefas);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> VisualiarTarefa (Guid id)
        {

            var encontrarTarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
            
            if(encontrarTarefa == null)
                return NotFound("Tarefa nao encontrada");

            return Ok(encontrarTarefa);
        }

        [HttpPost]
        public async Task<IActionResult> CriarTarefa (Tarefa tarefa)
        {

            var novaTarefa = new Tarefa
            {
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao
            };

            _context.Tarefas.Add(novaTarefa);

           await _context.SaveChangesAsync();

            return Created($"/api/tarefas/{novaTarefa.Id}", novaTarefa);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> AtualizarTarefa(Guid id, [FromBody]Tarefa tarefaAtualizada)
        {
            var encontrarTarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);

            if (encontrarTarefa == null)
                return NotFound("Tarefa nao encontrada");

            encontrarTarefa.Titulo = tarefaAtualizada.Titulo;
            encontrarTarefa.Descricao = tarefaAtualizada.Descricao;

            await _context.SaveChangesAsync();

            return Ok(encontrarTarefa);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletarTarefa(Guid id)
        {
            var encontrarTarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);

            if (encontrarTarefa == null)
                return NotFound("Tarefa nao encontrada");

            _context.Tarefas.Remove(encontrarTarefa);

            await _context.SaveChangesAsync();

            return NoContent();
        }




    }
}