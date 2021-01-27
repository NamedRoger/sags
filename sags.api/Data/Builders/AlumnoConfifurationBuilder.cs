using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sags.api.Models;

namespace sags.api.Data.Builders
{
    public class AlumnoTypeConfiguration : IEntityTypeConfiguration<Alumno>
    {
        public void Configure(EntityTypeBuilder<Alumno> builder)
        {
            builder.ToTable("alumnos");
            builder.HasKey(a => a.IdAlumno);
            

            //relacion mucho a muchos 
            builder.HasMany(a => a.Clases)
            .WithMany(c => c.Alumnos)
            .UsingEntity<AlumnoClase>(
                j => j.HasOne(ac => ac.Clase)
                .WithMany(c => c.AlumnoClases)
                .HasForeignKey(ac => ac.IdClase),
                j => j.HasOne(ac => ac.Alumno)
                .WithMany(a => a.AlumnoClases)
                .HasForeignKey(ac => ac.IdAlumno),
                j => j.HasKey(j => j.IdAlumnoClase)
            );

            //relacion uno a uno 
            builder.HasOne(a => a.Usuario)
            .WithMany()
            .HasForeignKey(u => u.IdUsuario);

            // establece el valor por defecto
            builder.Property(a => a.Borrado).HasDefaultValue(false);

            // estabele los indices y establece que son unicos
            builder.HasIndex(a => a.Matricula).IsUnique();
            builder.HasIndex(a => a.Curp).IsUnique();
        }
    }
}