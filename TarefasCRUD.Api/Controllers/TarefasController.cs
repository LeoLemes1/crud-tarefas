using Microsoft.AspNetCore.Mvc;
using TarefasCRUD.Application.DTOs;
using TarefasCRUD.Application.Handlers.AtualizarTarefa;
using TarefasCRUD.Application.Handlers.BuscarTarefaPorId;
using TarefasCRUD.Application.Handlers.BuscarTodasAsTarefas;
using TarefasCRUD.Application.Handlers.CriarTarefa;
using TarefasCRUD.Application.Handlers.DeletarTarefa;

namespace TarefasCRUD.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefasController : ControllerBase
{
    private readonly AtualizarTarefaHandler _atualizarTarefaHandler;
    private readonly BuscarTodasAsTarefasHandler _buscarTodasAsTarefasHandler;
    private readonly BuscarTarefaPorIdHandler _buscarTarefaPorIdHandler;
    private readonly CriarTarefaHandler _criarTarefaHandler;
    private readonly DeletarTarefaHandler _deletarTarefaHandler;

    public TarefasController(
        AtualizarTarefaHandler atualizarTarefaHandler,
        BuscarTodasAsTarefasHandler buscarTodasAsTarefasHandler,
        BuscarTarefaPorIdHandler buscarTarefaPorIdHandler,
        CriarTarefaHandler criarTarefaHandler,
        DeletarTarefaHandler deletarTarefaHandler)
    {
        _atualizarTarefaHandler = atualizarTarefaHandler;
        _buscarTodasAsTarefasHandler = buscarTodasAsTarefasHandler;
        _buscarTarefaPorIdHandler = buscarTarefaPorIdHandler;
        _criarTarefaHandler = criarTarefaHandler;
        _deletarTarefaHandler = deletarTarefaHandler;
    }

    [HttpGet]
    public async Task<IActionResult> ListarTodasAsTarefas()
    {
        var response = await _buscarTodasAsTarefasHandler.Handle();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ListarTarefaPorId(Guid id)
    {
        var response = await _buscarTarefaPorIdHandler.Handle(id);

        if (response == null)
            return NotFound("Tarefa não encontrada.");

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CriarTarefa([FromBody] TarefaRequest? request)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.Titulo) || string.IsNullOrWhiteSpace(request.Descricao))
            return BadRequest("Titulo e Descricao sao obrigatorios");

        var response = await _criarTarefaHandler.Handle(request);
        if (response == null)
            return BadRequest("Titulo e Descricao sao obrigatorios");

        return Created($"/api/tarefas/{response.Id}", response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarTarefa(Guid id, [FromBody] TarefaRequest? request)
    {
        if (request == null || (string.IsNullOrWhiteSpace(request.Titulo) && string.IsNullOrWhiteSpace(request.Descricao)))
            return BadRequest("Informe pelo menos um dos campos: Titulo ou Descricao");

        var response = await _atualizarTarefaHandler.Handle(id, request);

        if (response == null)
            return NotFound("Tarefa não encontrada.");

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarTarefa(Guid id)
    {
        var deletado = await _deletarTarefaHandler.Handle(id);

        if (!deletado)
            return NotFound("Tarefa não encontrada");

        return NoContent();
    }
}
