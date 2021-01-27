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
    public class MaestroController : ControllerBase
    {
        private readonly SagsContext _context;

        public MaestroController(SagsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Maestro>> ListarMaestros([FromQuery] Paginacion paginacion){
            var queryableMaestros = _context.Maestros.AsQueryable();
            await HttpContext.AplicarPaginacion(queryableMaestros,paginacion.CantidadAMostrar);
            return await queryableMaestros.Paginar(paginacion).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Maestro>> ObtenerMaestro(Guid id){
            var maestro = await _context.Maestros.FindAsync(id);
            if(maestro == null) return NotFound("No se econtró el maestro");

            return maestro;
        }

        [HttpPost]
        public async Task<IActionResult> AgregarMaestro([FromBody] Maestro nuevoMaestro){
            try{
                await _context.Maestros.AddAsync(nuevoMaestro);
                return NoContent();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}