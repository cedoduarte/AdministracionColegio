using Microsoft.EntityFrameworkCore;

namespace AdministracionColegio.Models.Interface
{
    public interface IAppDbContext
    {
        DbSet<Alumno> Alumnos { get; set; }
        DbSet<AlumnoGrado> AlumnoGrados { get; set; }
        DbSet<Grado> Grados { get; set; }
        DbSet<Profesor> Profesores { get; set; }
    }
}
