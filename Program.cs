using Microsoft.EntityFrameworkCore;
using TarefasCRUD.Data;
using TarefasCRUD.Interfaces;
using TarefasCRUD.Repositorios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<TarefaDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepositorioTarefa, RepositorioTarefa>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
