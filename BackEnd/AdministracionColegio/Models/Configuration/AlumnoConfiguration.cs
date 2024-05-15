using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdministracionColegio.Models.Configuration
{
    public class AlumnoConfiguration : IEntityTypeConfiguration<Alumno>
    {
        public void Configure(EntityTypeBuilder<Alumno> builder)
        {
            builder.Property(a => a.Nombre).IsRequired().HasColumnType("VARCHAR(256)");
            builder.Property(a => a.Apellidos).IsRequired().HasColumnType("VARCHAR(256)");
            builder.Property(a => a.Genero).IsRequired().HasColumnType("VARCHAR(5)");
            builder.Property(a => a.FechaNacimiento).IsRequired().HasColumnType("DATETIME");
        }
    }
}
