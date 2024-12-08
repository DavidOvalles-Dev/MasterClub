using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolProjectWeb.Data;
using SchoolProjectWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolProjectWeb.Pages.Estudiantes
{
    [Authorize(Roles = "Administrador")] // Solo administradores pueden ver esta página
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Estudiante> Estudiantes { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                Estudiantes = await _context.Estudiantes.ToListAsync();
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error al cargar estudiantes: {ex.Message}");
            }
        }
    }
}
