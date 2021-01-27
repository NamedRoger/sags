using System.ComponentModel.DataAnnotations;

namespace sags.api.Models
{
    public class Dia
    {
        [Key]
        public int IdDia {get;set;}
        public string Nombre {get;set;}
    }
}