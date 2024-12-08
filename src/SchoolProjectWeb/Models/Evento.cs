using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolProjectWeb.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del evento es obligatorio.")]
        public string NombreEvento { get; set; }

        [Required(ErrorMessage = "La actividad es obligatoria.")]
        public int ActividadId { get; set; }

        public Actividad? Actividad { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El lugar es obligatorio.")]
        public string Lugar { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Descripcion { get; set; }
    }
}
