using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdministracionColegio.Models.Configuration
{
    public class GradoConfiguration : IEntityTypeConfiguration<Grado>
    {
        public void Configure(EntityTypeBuilder<Grado> builder)
        {
            builder.Property(g => g.Nombre).IsRequired().HasColumnType("VARCHAR(256)");
            builder.Property(g => g.ProfesorId).IsRequired().HasColumnType("BIGINT");
        }
    }
}
