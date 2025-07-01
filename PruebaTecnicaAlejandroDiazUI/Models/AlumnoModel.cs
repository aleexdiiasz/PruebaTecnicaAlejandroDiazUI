using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaAlejandroDiaz.Models
{
    public class AlumnoModel
    {
        [Key]
        public int AlumnoId { get; set; } // Número de identificación único
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public ICollection<AlumnoProfesorModel> AlumnoProfesores { get; set; }
        public ICollection<AlumnoEscuelaModel> AlumnoEscuelas { get; set; }
    }
}
