using System.ComponentModel.DataAnnotations;

public class Estudiante
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }
    public string Grado { get; set; }
    public DateTime FechaNacimiento { get; set; }
}
