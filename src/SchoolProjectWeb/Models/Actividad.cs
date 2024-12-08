using SchoolProjectWeb.Models;

public class Actividad
{
    public int Id { get; set; }
    public string NombreActividad { get; set; }
    public string Descripcion { get; set; }
    public int CupoMaximo { get; set; }

    public int ProfesorId { get; set; }

    public Profesor? Profesor { get; set; }
}
