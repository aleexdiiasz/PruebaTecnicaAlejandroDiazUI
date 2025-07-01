using System.ComponentModel.DataAnnotations;
using PruebaTecnicaAlejandroDiazUI.Models;

namespace PruebaTecnicaAlejandroDiaz.Models
{
    public class ProfesorModel
    {
        [Key]
        public int ProfesorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Identificacion { get; set; }
        public int EscuelaId { get; set; }
        public ICollection<AlumnoProfesorModel> AlumnoProfesores { get; set; }
    }
}
