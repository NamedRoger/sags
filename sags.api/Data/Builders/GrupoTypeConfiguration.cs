using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sags.api.Models;

namespace sags.api.Data.Builders
{
    public class GrupoTypeConfiguration : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.ToTable("gurpos");
            builder.HasKey(g => g.IdGrupo);

            builder.HasOne(g => g.Carrera)
            .WithMany()
            .HasForeignKey(g => g.IdCarrera);

            builder.Property(g => g.Borrado).HasDefaultValue(false);

        }
    }
}