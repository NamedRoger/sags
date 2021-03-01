using System;

namespace sags.api.Models
{
    public class AlumnoClase
    {
        public Guid IdAlumnoClase {get;set;}
        public Guid IdClase {get;set;}
        public Clase Clase {get;set;}
        public Guid IdAlumno {get;set;}
        public Alumno Alumno {get;set;}
        public Guid IPeriodo {get;set;}
        public Periodo Periodo {get;set;}
        public double Calificacion {get;set;}
        public double PrimerParcial {get;set;}
        public double SegundoParcial {get;set;}
        public double TercerPacrial {get;set;}

    }
}