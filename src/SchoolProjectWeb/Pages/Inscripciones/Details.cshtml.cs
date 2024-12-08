using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolProjectWeb.Data;
using SchoolProjectWeb.Models;

namespace SchoolProjectWeb.Pages_Inscripciones
{
    [Authorize(Roles = "Administrador")]

    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Inscripcion Inscripcion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Carga de la inscripción con Estudiante y Actividad utilizando Eager Loading (Include)
            var inscripcion = await _context.Inscripciones
                                            .Include(i => i.Estudiante)  // Incluye la entidad Estudiante relacionada
                                            .Include(i => i.Actividad)   // Incluye la entidad Actividad relacionada
                                            .FirstOrDefaultAsync(m => m.Id == id);

            if (inscripcion == null)
            {
                return NotFound();
            }

            Inscripcion = inscripcion;
            return Page();
        }
    }
}
