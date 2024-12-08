using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolProjectWeb.Data;
using SchoolProjectWeb.Models;

namespace SchoolProjectWeb.Pages.Actividades
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Actividad Actividad { get; set; }

        public IActionResult OnGet()
        {
            ViewData["ProfesorId"] = new SelectList(_context.Profesores, "Id", "Nombre");
            return Page();
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("Método OnPost llamado...");
            Console.WriteLine($"NombreActividad: {Actividad.NombreActividad}");
            Console.WriteLine($"Descripcion: {Actividad.Descripcion}");
            Console.WriteLine($"CupoMaximo: {Actividad.CupoMaximo}");
            Console.WriteLine($"ProfesorId: {Actividad.ProfesorId}");

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Error de validación: {error.ErrorMessage}");
                }
                ViewData["ProfesorId"] = new SelectList(_context.Profesores, "Id", "Nombre");
                return Page();
            }

            try
            {
                _context.Actividades.Add(Actividad);
                _context.SaveChanges();
                Console.WriteLine("Actividad creada exitosamente.");
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar la actividad: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Error al guardar la actividad.");
                ViewData["ProfesorId"] = new SelectList(_context.Profesores, "Id", "Nombre");
                return Page();
            }
        }

    }

}


