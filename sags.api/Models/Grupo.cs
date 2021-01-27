namespace sags.api.Models
{
    public class Grupo
    {
        public int IdGrupo {get;set;}
        public string Nombre {get;set;}
        public bool Borrado {get;set;}
        public int IdCarrera {get;set;}
        public Carrera Carrera {get;set;}
    }
}