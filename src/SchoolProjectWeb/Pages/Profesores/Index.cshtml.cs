using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolProjectWeb.Data;
using SchoolProjectWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolProjectWeb.Pages.Profesores
{

    [Authorize(Roles = "Administrador")] 
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Profesor> Profesores { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                Profesores = await _context.Profesores.ToListAsync();
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error al cargar profesores: {ex.Message}");
            }
        }
    }
}
