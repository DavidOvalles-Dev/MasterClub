using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolProjectWeb.Data;
using SchoolProjectWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;



namespace SchoolProjectWeb.Pages.Eventos
{
    [Authorize(Roles = "Estudiante,Administrador")]

    public class IndexModel : PageModel
    {
        
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Evento> Eventos { get; set; }

        public async Task OnGetAsync()
        {
            Eventos = await _context.Eventos
                .Include(e => e.Actividad)
                .ToListAsync();
        }
    }
}
