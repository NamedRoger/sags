using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sags.api.Models;

namespace sags.api.Data.Builders
{
    public class PeriodoTypeConfiguration : IEntityTypeConfiguration<Periodo>
    {
        public void Configure(EntityTypeBuilder<Periodo> builder)
        {
            builder.ToTable("periodos");
            builder.HasKey(p => p.IdPeriodo);

            builder.Property(p => p.Borrado).HasDefaultValue(false);
        }
    }
}