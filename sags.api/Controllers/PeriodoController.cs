using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sags.api.Data;
using sags.api.Helpers.Http;
using sags.api.Models;

namespace sags_api.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class PeriodoController : ControllerBase
    {
        private readonly SagsContext _context;

        public PeriodoController(SagsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Periodo>> ListarPeriodos([FromQuery] Paginacion paginacion){
            var queryablePeriodos = _context.Periodos.AsQueryable();
            await HttpContext.AplicarPaginacion(queryablePeriodos,paginacion.CantidadAMostrar);
            return await queryablePeriodos.Paginar(paginacion).ToListAsync();
        }   

        [HttpGet("{id}")]
        public async Task<ActionResult<Periodo>> ObtenerPeriodo(Guid id){
            var periodo = await _context.Periodos.FindAsync(id);
            if(periodo == null) return NotFound("No se encontró el periodo");
            return periodo;
        }

        [HttpPost]
        public async Task<IActionResult> AgregarPeriodo([FromBody] Periodo periodo){
            try{
                await _context.Periodos.AddAsync(periodo);
                return NoContent();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}