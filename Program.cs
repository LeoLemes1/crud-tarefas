using Microsoft.EntityFrameworkCore;
using TarefasCRUD.Data;
using TarefasCRUD.Handlers.AtualizarTarefa;
using TarefasCRUD.Handlers.BuscarTarefaPorId;
using TarefasCRUD.Handlers.BuscarTodasAsTarefas;
using TarefasCRUD.Handlers.CriarTarefa;
using TarefasCRUD.Handlers.DeletarTarefa;
using TarefasCRUD.Interfaces;
using TarefasCRUD.Repositorios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<TarefaDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRepositorioTarefa, RepositorioTarefa>();
builder.Services.AddScoped<AtualizarTarefaHandler>();
builder.Services.AddScoped<BuscarTarefaPorIdHandler>();
builder.Services.AddScoped<BuscarTodasAsTarefasHandler>();
builder.Services.AddScoped<CriarTarefaHandler>();
builder.Services.AddScoped<DeletarTarefaHandler>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
