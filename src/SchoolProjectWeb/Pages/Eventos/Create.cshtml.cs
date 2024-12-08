using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolProjectWeb.Data;
using SchoolProjectWeb.Models;

namespace SchoolProjectWeb.Pages.Eventos
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Evento Evento { get; set; }

        public IActionResult OnGet()
        {
            ViewData["ActividadId"] = new SelectList(_context.Actividades, "Id", "NombreActividad");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ActividadId"] = new SelectList(_context.Actividades, "Id", "NombreActividad");
                return Page();
            }

            try
            {
                _context.Eventos.Add(Evento);  
                _context.SaveChanges();       

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                // Manejar errores al guardar
                ModelState.AddModelError(string.Empty, "Error al guardar el evento.");
                ViewData["ActividadId"] = new SelectList(_context.Actividades, "Id", "NombreActividad");
                return Page();
            }
        }
    }
}
