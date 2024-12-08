
using SchoolProjectWeb.Models;
using System.ComponentModel.DataAnnotations;
public class Inscripcion
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un usuario.")]
    public int EstudianteId { get; set; }

    [Required(ErrorMessage = "Debe seleccionar una actividad.")]
    public int ActividadId { get; set; }

    [Required(ErrorMessage = "Debe ingresar una fecha de inscripción.")]
    public DateTime FechaInscripcion { get; set; }

    public Estudiante? Estudiante { get; set; }
    public Actividad? Actividad { get; set; }


}
