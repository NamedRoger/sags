using System;
using System.Collections.Generic;

namespace sags.api.Models
{
    public class Alumno
    {
        public Guid IdAlumno {get;set;}
        public Guid IdUsuario {get;set;}
        public Usuario Usuario {get;set;}
        public string Matricula {get;set;}
        public string Nombre {get;set;}
        public string ApellidoPaterno {get;set;}
        public string ApellidoMaterno {get;set;}
        public DateTime FechaNacimiento {get;set;}
        public DateTime FechaIngreso {get;set;}
        public string Curp {get;set;}
        public bool Borrado {get;set;}

        public ICollection<Clase> Clases {get;set;}
        public List<AlumnoClase> AlumnoClases {get;set;}

    }
}