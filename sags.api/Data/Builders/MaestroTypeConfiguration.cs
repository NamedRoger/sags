using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sags.api.Models;

namespace sags.api.Data.Builders
{
    public class MaestroTypeConfiguration : IEntityTypeConfiguration<Maestro>
    {
        public void Configure(EntityTypeBuilder<Maestro> builder)
        {
            builder.ToTable("maestros");
            builder.HasKey(m => m.IdMaestro);

            builder.Property(m => m.Borrado).HasDefaultValue(false);
        }
    }
}