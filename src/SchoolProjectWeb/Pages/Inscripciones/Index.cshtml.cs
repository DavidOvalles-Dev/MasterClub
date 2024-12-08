using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolProjectWeb.Data;
using SchoolProjectWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolProjectWeb.Pages.Inscripciones
{
    [Authorize(Roles = "Administrador")] 
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Inscripcion> Inscripciones { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                Inscripciones = await _context.Inscripciones
                    .Include(i => i.Estudiante)
                    .Include(i => i.Actividad)
                    .ToListAsync();
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error al cargar inscripciones: {ex.Message}");
            }
        }
    }
}
