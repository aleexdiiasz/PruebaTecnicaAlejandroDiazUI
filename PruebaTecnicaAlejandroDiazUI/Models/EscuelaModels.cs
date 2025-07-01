using PruebaTecnicaAlejandroDiaz.Models;

namespace PruebaTecnicaAlejandroDiazUI.Models;

public class EscuelaModels
{

    public int EscuelaId { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public ICollection<AlumnoProfesorModel> Profesores { get; set; }
    public ICollection<AlumnoEscuelaModel> AlumnoEscuelas { get; set; }

}
