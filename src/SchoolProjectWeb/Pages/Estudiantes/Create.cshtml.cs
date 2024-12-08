using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProjectWeb.Data;
using SchoolProjectWeb.Models;

namespace SchoolProjectWeb.Pages.Estudiantes
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Estudiante Estudiante { get; set; } = new Estudiante(); 

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("Método OnPost llamado...");
            Console.WriteLine($"Nombre: {Estudiante.Nombre}");
            Console.WriteLine($"Apellido: {Estudiante.Apellido}");
            Console.WriteLine($"Grado: {Estudiante.Grado}");
            Console.WriteLine($"FechaNacimiento: {Estudiante.FechaNacimiento}");

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Error de validación: {error.ErrorMessage}");
                }
                return Page();
            }

            try
            {
                _context.Estudiantes.Add(Estudiante);
                _context.SaveChanges();
                Console.WriteLine("Estudiante registrado exitosamente.");
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el estudiante: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Error al guardar el estudiante.");
                return Page();
            }
        }
    }
}
