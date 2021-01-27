using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sags.api.Models;

namespace sags.api.Data.Builders
{
    public class CarreraTypeConfiguration : IEntityTypeConfiguration<Carrera>
    {
        public void Configure(EntityTypeBuilder<Carrera> builder)
        {
            builder.ToTable("carreras");
            builder.HasKey(c => c.IdCarrera);
            
            // establece el valor por defecto en la propiedad 
            builder.Property(c => c.Borrado).HasDefaultValue(false);
        }
    }
}