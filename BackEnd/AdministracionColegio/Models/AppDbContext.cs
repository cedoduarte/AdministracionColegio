using AdministracionColegio.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace AdministracionColegio.Models
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<AlumnoGrado> AlumnoGrados { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<Profesor> Profesores { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAppDbContext).Assembly);
        }
    }
}
