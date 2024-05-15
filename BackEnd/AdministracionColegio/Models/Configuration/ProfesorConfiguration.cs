using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdministracionColegio.Models.Configuration
{
    public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
    {
        public void Configure(EntityTypeBuilder<Profesor> builder)
        {
            builder.Property(p => p.Nombre).IsRequired().HasColumnType("VARCHAR(256)");
            builder.Property(p => p.Apellidos).IsRequired().HasColumnType("VARCHAR(256)");
            builder.Property(p => p.Genero).IsRequired().HasColumnType("VARCHAR(5)");
        }
    }
}
