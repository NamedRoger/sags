using System.Linq;

namespace sags.api.Helpers.Http
{
    public class Paginacion
    {
        public int Pagina {get;set;} = 1;
        public int CantidadAMostrar {get;set;} = 15;
    }
}