using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolProjectWeb.Data;
using SchoolProjectWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolProjectWeb.Pages.Actividades
{
    [Authorize(Roles = "Administrador")] // Restringir acceso solo a Administradores
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // Constructor que inyecta el DbContext
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lista para almacenar las Actividades y enviarlas a la vista
        public IList<Actividad> Actividades { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                // Obtener todas las Actividades e incluir la relación con el Profesor
                Actividades = await _context.Actividades
                    .Include(a => a.Profesor)
                    .ToListAsync();
            }
            catch (System.Exception ex)
            {
                // Loguear el error (opcional)
                ModelState.AddModelError(string.Empty, "Ocurrió un error al obtener las actividades.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
