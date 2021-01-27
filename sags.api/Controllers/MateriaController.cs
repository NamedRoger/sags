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
    public class MateriaController : ControllerBase
    {
        private readonly SagsContext _context;

        public MateriaController(SagsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Materia>> ListarMaterias([FromQuery] Paginacion paginacion){
            var queryableMaterias = _context.Materias.AsQueryable();
            await HttpContext.AplicarPaginacion(queryableMaterias,paginacion.CantidadAMostrar);
            return await queryableMaterias.Paginar(paginacion).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Materia>> ObtenerMateria(int id){
            var materia = await _context.Materias.FindAsync(id);
            if(materia == null) return NotFound("No se encontró la materia");
            return materia;
        }

        [HttpPost]
        public async Task<IActionResult> AgregarMateria([FromBody] Materia nuevMateria){
            try{
                await _context.Materias.AddAsync(nuevMateria);
                return NoContent();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}