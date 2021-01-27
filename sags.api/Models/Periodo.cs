using System;

namespace sags.api.Models
{
    public class Periodo
    {
        public Guid IdPeriodo {get;set;}
        public string NombrePeriodo {get;set;}
        public DateTime FechaInicio {get;set;}
        public DateTime FechaFin {get;set;}
        public bool Borrado {get;set;}

    }
}