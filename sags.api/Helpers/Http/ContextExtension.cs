using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace sags.api.Helpers.Http
{
    public static class ContextExtension
    {
        public static async Task AplicarPaginacion<T>(this HttpContext context, 
        IQueryable<T> queryable, int registrosAMostrar){

            if(context == null) throw new ArgumentNullException(nameof(context));

            // hace un conteo de la cantidad de registros en la entidad
            double conteo = await queryable.CountAsync();
            double totalPaginas = Math.Ceiling(conteo/registrosAMostrar)*registrosAMostrar;

            context.Response.Headers.Add("totalPaginas",totalPaginas.ToString());
        }
    }
}