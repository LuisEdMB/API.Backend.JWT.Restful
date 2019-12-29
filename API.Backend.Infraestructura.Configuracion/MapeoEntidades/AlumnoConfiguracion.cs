using API.Backend.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Backend.Infraestructura.Configuracion.MapeoEntidades
{
    public class AlumnoConfiguracion : IEntityTypeConfiguration<Alumno>
    {
        public void Configure(EntityTypeBuilder<Alumno> builder)
        {
            builder.ToTable("RE_ALUMNO", "RE");
            builder.HasKey(g => g.CodigoAlumno);

            builder.Property(x => x.CodigoAlumno).HasColumnName("COD_ALUMNO");
            builder.Property(x => x.NombreAlumno).HasColumnName("NOM_ALUMNO");
            builder.Property(x => x.ApellidoAlumno).HasColumnName("APE_ALUMNO");
            builder.Property(x => x.Edad).HasColumnName("NUM_EDAD");
            builder.Property(x => x.FechaNacimiento).HasColumnName("FEC_NACIMIENTO");
            builder.Property(x => x.IndicadorEstado).HasColumnName("IND_ESTADO");
        }
    }
}
