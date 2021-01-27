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
    public class CarreraController : ControllerBase
    {
        private readonly SagsContext _context;

        public CarreraController(SagsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Carrera>> ListarCarrera([FromQuery] Paginacion paginacion){
            var queryableCarreras = _context.Carreras.AsQueryable();
            await HttpContext.AplicarPaginacion(queryableCarreras,paginacion.CantidadAMostrar);
            return await queryableCarreras.Paginar(paginacion).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carrera>> ObtenerCarrera(int id){
            var carrera = await _context.Carreras.FindAsync(id);
            if(carrera == null) return NotFound("No se encontró la carrera");

            return carrera;
        }

        [HttpPost]
        public async Task<IActionResult> AgregarCarrera([FromBody] Carrera nuevaCarrera){
            try{
                await _context.Carreras.AddAsync(nuevaCarrera);
                return NoContent();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        
    }
}