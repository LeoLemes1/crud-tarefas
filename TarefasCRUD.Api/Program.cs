using TarefasCRUD.Application.Extensions;
using TarefasCRUD.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection")!);
builder.Services.AddApplication();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
