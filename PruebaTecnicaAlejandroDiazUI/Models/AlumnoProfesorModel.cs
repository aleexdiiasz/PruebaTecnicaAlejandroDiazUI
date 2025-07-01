using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaAlejandroDiaz.Models
{
    public class AlumnoProfesorModel
    {
        [Key]
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public int ProfesorId { get; set; }
    }
}
