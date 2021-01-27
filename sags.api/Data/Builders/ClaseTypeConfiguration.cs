using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sags.api.Models;

namespace sags.api.Data.Builders
{
    public class ClaseTypeConfiguration : IEntityTypeConfiguration<Clase>
    {
        public void Configure(EntityTypeBuilder<Clase> builder)
        {
            builder.ToTable("clases");
            builder.HasKey(c => c.IdClase);

            builder.HasOne(c => c.Periodo)
            .WithMany()
            .HasForeignKey(c => c.IdPeriodo);

            builder.HasOne(c => c.Grupo)
            .WithMany()
            .HasForeignKey(c => c.IdGrupo);

            builder.HasOne(c => c.Maestro)
            .WithMany()
            .HasForeignKey(c => c.IdMaestro);

            builder.HasOne(c => c.Materia)
            .WithMany()
            .HasForeignKey(c => c.IdMateria);
        }
    }
}