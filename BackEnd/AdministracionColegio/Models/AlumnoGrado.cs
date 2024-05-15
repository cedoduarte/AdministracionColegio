using System.Text.RegularExpressions;

namespace AdministracionColegio.Models
{
    public class AlumnoGrado
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public int GradoId { get; set; }
        public string Seccion { get; set; } // grupo

        public virtual Alumno Alumno { get; set; }
        public virtual Grado Grado { get; set; }
    }
}
