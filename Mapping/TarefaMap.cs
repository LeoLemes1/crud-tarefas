using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TarefasCRUD.Entidades;

namespace TarefasCRUD.Mapping
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.Property(x => x.Titulo)
                .HasMaxLength(200);

            builder.Property(x => x.Descricao)
                .HasMaxLength(1000);

            builder.Property(x => x.CriacaoAt);
        }
    }
}
