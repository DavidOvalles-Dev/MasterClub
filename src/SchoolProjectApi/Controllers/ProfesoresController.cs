using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProjectWeb.Data;
using SchoolProjectWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProjectWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfesoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/profesores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesor>>> GetProfesores()
        {
            return await _context.Profesores.ToListAsync();
        }

        // GET: api/profesores/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesor>> GetProfesor(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);

            if (profesor == null)
            {
                return NotFound();
            }

            return profesor;
        }
        private bool ProfesorExists(int id)
        {
            return _context.Profesores.Any(e => e.Id == id);
        }

        // POST: api/profesores
        [HttpPost]
        public async Task<ActionResult<Profesor>> PostProfesor(Profesor profesor)
        {
            _context.Profesores.Add(profesor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProfesor), new { id = profesor.Id }, profesor);
        }
        // Suponiendo que tu controlador tiene algo como esto para eliminar un profesor.
[HttpDelete("{id}")]
public async Task<ActionResult> DeleteProfesor(int id)
{
    var profesor = await _context.Profesores.FindAsync(id);
    if (profesor == null)
    {
        return NotFound();  // Si no se encuentra el profesor, devolvemos un "Not Found".
    }

    _context.Profesores.Remove(profesor);  // Elimina el profesor de la base de datos.
    await _context.SaveChangesAsync();    // Guarda los cambios.

    return NoContent();  // Devuelve un 204 No Content indicando que la eliminación fue exitosa.
}

        // PUT: api/profesores/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesor(int id, Profesor profesor)
        {
            if (id != profesor.Id)
            {
                return BadRequest();
            }

            _context.Entry(profesor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

     


    }
}

