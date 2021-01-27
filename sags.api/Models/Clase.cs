
using System;
using System.Collections.Generic;

namespace sags.api.Models
{
    public class Clase
    {
        public Guid IdClase {get;set;}
        public Guid IdMaestro {get;set;}
        public Maestro Maestro {get;set;}
        public int IdMateria {get;set;}
        public Materia Materia {get;set;}
        public int IdGrupo {get;set;}
        public Grupo Grupo {get;set;}
        public Guid IdPeriodo {get;set;}
        public Periodo Periodo {get;set;}
        public double PrimerParcial {get;set;}
        public double SegundoParcial {get;set;}
        public double TercerPacrial {get;set;}

        
        public ICollection<Alumno> Alumnos {get;set;}
        public List<AlumnoClase> AlumnoClases {get;set;}
    }
}