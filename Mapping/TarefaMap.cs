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

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.Titulo)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(x => x.CriadoEm)
                .HasColumnName("CriacaoAt")
                .IsRequired();
        }
    }
}
