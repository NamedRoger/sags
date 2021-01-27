using System.ComponentModel.DataAnnotations;

namespace sags.api.Models
{
    public class Materia
    {
        [Key]
        public int IdMateria {get;set;}
        public string Nombre {get;set;}
        public bool Borrado {get;set;}
    }
}