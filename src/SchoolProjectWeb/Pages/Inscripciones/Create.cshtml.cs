using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolProjectWeb.Data;
using SchoolProjectWeb.Models;

namespace SchoolProjectWeb.Pages_Inscripciones
{
    [Authorize(Roles = "Estudiante,Administrador")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inscripcion Inscripcion { get; set; }

        public SelectList Estudiantes { get; set; }
        public SelectList Actividades { get; set; }

        public IActionResult OnGet()
        {
            Inscripcion = new Inscripcion
            {
                FechaInscripcion = DateTime.Now
            };

            Estudiantes = new SelectList(_context.Estudiantes, "Id", "Nombre");
            Actividades = new SelectList(_context.Actividades, "Id", "NombreActividad");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Estudiantes = new SelectList(_context.Estudiantes, "Id", "Nombre");
                Actividades = new SelectList(_context.Actividades, "Id", "NombreActividad");
                return Page();
            }

            try
            {
                _context.Inscripciones.Add(Inscripcion);
                _context.SaveChanges();

                if (User.IsInRole("Estudiante"))
                {
                    return RedirectToPage("/Eventos/Index");
                }

                return RedirectToPage("./Index");
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error al guardar la inscripción: {ex.Message}");
                Estudiantes = new SelectList(_context.Estudiantes, "Id", "Nombre");
                Actividades = new SelectList(_context.Actividades, "Id", "NombreActividad");
                return Page();
            }
        }
    }
}
