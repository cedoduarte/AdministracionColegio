using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdministracionColegio.Models.Configuration
{
    public class AlumnoGradoConfiguration : IEntityTypeConfiguration<AlumnoGrado>
    {
        public void Configure(EntityTypeBuilder<AlumnoGrado> builder)
        {
            builder.Property(a => a.AlumnoId).IsRequired().HasColumnType("BIGINT");
            builder.Property(a => a.GradoId).IsRequired().HasColumnType("BIGINT");
            builder.Property(a => a.Seccion).IsRequired().HasColumnType("VARCHAR(256)");
        }
    }
}
