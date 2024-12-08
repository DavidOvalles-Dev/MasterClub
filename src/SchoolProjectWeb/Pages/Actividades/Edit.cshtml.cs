using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolProjectWeb.Data;
using SchoolProjectWeb.Models;

namespace SchoolProjectWeb.Pages.Actividades
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Actividad Actividad { get; set; }

        public IActionResult OnGet(int id)
        {
            Actividad = _context.Actividades.FirstOrDefault(a => a.Id == id);
            if (Actividad == null)
            {
                return NotFound();
            }

            // Cargar la lista de profesores en ViewData para el dropdown
            ViewData["ProfesorId"] = new SelectList(_context.Profesores, "Id", "Nombre");
            return Page();
        }

        public IActionResult OnPost()
        {
            // Lógica de validación y guardado
            if (!ModelState.IsValid)
            {
                ViewData["ProfesorId"] = new SelectList(_context.Profesores, "Id", "Nombre");
                return Page();
            }

            try
            {
                _context.Attach(Actividad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al actualizar la actividad.");
                ViewData["ProfesorId"] = new SelectList(_context.Profesores, "Id", "Nombre");
                return Page();
            }
        }
    }
}
