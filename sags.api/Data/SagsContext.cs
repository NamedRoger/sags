using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sags.api.Data.Builders;
using sags.api.Models;

namespace sags.api.Data
{
    public class SagsContext : IdentityDbContext<Usuario,IdentityRole<Guid>,Guid>
    {
        public SagsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Alumno> Alumnos {get;set;}
        public DbSet<Clase> Clases {get;set;}
        public DbSet<AlumnoClase> AlumnoClases {get;set;}
        public DbSet<Carrera> Carreras {get;set;}
        public DbSet<Dia> Dias {get;set;}
        public DbSet<Maestro> Maestros {get;set;}
        public DbSet<Materia> Materias {get;set;}
        public DbSet<Periodo> Periodos {get;set;}
        public DbSet<Grupo> Grupos {get;set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AlumnoTypeConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(GrupoTypeConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(ClaseTypeConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(PeriodoTypeConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(MaestroTypeConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(CarreraTypeConfiguration).Assembly);
        }
    }   
}