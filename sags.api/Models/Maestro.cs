using System;

namespace sags.api.Models
{
    public class Maestro
    {
        public Guid IdMaestro {get;set;}
        public string Nombre {get;set;}
        public string ApellidoPaterno {get;set;}
        public string ApellidoMaterno {get;set;}
        public bool Borrado {get;set;}
    }
}