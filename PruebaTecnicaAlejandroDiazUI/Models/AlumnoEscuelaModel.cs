using System.ComponentModel.DataAnnotations;
using PruebaTecnicaAlejandroDiazUI.Models;

namespace PruebaTecnicaAlejandroDiaz.Models
{
    public class AlumnoEscuelaModel
    {
        [Key]
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public int EscuelaId { get; set; }
    }
}
