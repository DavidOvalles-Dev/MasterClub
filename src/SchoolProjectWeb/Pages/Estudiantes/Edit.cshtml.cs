using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolProjectWeb.Data;
using SchoolProjectWeb.Models;

namespace SchoolProjectWeb.Pages.Estudiantes
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Estudiante Estudiante { get; set; } = default!;

        // M�todo GET para cargar el estudiante en la vista
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Obtener el estudiante por ID
            Estudiante = await _context.Estudiantes.FirstOrDefaultAsync(m => m.Id == id);

            if (Estudiante == null)
            {
                return NotFound();
            }

            return Page();
        }

        // M�todo POST para actualizar los datos del estudiante
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Marcar como modificado el objeto Estudiante
            _context.Attach(Estudiante).State = EntityState.Modified;

            try
            {
                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(Estudiante.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        // M�todo auxiliar para verificar si el estudiante existe
        private bool EstudianteExists(int id)
        {
            return _context.Estudiantes.Any(e => e.Id == id);
        }
    }
}
