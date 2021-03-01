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
    public class GrupoController : ControllerBase
    {
        private readonly SagsContext _context;

        public GrupoController(SagsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Grupo>> ListarGrupos([FromQuery] Paginacion paginacion){
            var queryableGrupos = _context.Grupos.Where(g => !g.Borrado).AsQueryable();
            await HttpContext.AplicarPaginacion(queryableGrupos,paginacion.CantidadAMostrar);
            return await queryableGrupos.Paginar(paginacion).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Grupo>> ObtenerAlumno(int id){
            var alumno = await _context.Grupos.FindAsync(id);
            if(alumno == null) return NotFound("No se encontró el Grupo");

            return alumno;
        }

        [HttpPost]
        public async Task<IActionResult> AgregarGrupo([FromBody] Grupo grupo){
            try{
                await _context.Grupos.AddAsync(grupo);
                return Ok();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarGrupo(int id, [FromBody] Grupo grupo){
            var grupoActual = await _context.Grupos.FindAsync(id);
            if(grupoActual == null) return NotFound("No se encontró el grupo");

            grupoActual.IdCarrera = grupo.IdCarrera;
            grupoActual.Nombre = grupo.Nombre;

            await _context.SaveChangesAsync();

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DesactivarGrupo(int id){
            try{
                var grupo = await _context.Grupos.FindAsync(id);
                if(grupo == null) return NotFound();

                grupo.Borrado = true;
                return NoContent();
            }catch(Exception e){
                return BadRequest(e);
            }
        }

    }
}