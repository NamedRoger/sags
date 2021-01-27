using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sags.api.Data;
using sags.api.Models;

namespace sags.api.Repositories
{
    public class AlumnoRepository : Repository<Alumno, Guid>
    {
        public AlumnoRepository(SagsContext context) : base(context)
        {
        }

        public async Task AgregarClase(Alumno alumno, Clase clase){
            alumno.Clases.Add(clase);
            await _context.SaveChangesAsync();
        }

        public async Task AgregarClases(Alumno alumno, List<Clase> clases){
            clases.ForEach(clase => alumno.Clases.Add(clase));
            await _context.SaveChangesAsync();
        }

        public async Task CalificarClase(Clase clase,Dictionary<string,double> calificaciones){
            foreach(var calificacion in calificaciones){
                var propiedad = clase.GetType().GetProperty(calificacion.Key);
                propiedad.SetValue(clase,calificacion.Value);
            }
            await _context.SaveChangesAsync(); 
        }

    }
}