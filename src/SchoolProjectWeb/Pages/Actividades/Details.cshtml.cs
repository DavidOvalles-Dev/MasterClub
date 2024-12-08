using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolProjectWeb.Data;
using SchoolProjectWeb.Models;

namespace SchoolProjectWeb.Pages.Actividades  // Cambiado aquí
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Actividad Actividad { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Carga de la actividad con el profesor encargado utilizando Eager Loading (Include)
            var actividad = await _context.Actividades
                                          .Include(a => a.Profesor)  // Incluye la entidad Profesor relacionada
                                          .FirstOrDefaultAsync(m => m.Id == id);

            if (actividad == null)
            {
                return NotFound();
            }

            Actividad = actividad;
            return Page();
        }
    }
}
