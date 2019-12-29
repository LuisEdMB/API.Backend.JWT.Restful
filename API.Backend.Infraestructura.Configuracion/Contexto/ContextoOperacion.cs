using API.Backend.Infraestructura.Configuracion.MapeoEntidades;
using Microsoft.EntityFrameworkCore;

namespace API.Backend.Infraestructura.Configuracion.Contexto
{
    public class ContextoOperacion : DbContext
    {
        public ContextoOperacion(DbContextOptions<ContextoOperacion> contexto)
            : base(contexto)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlumnoConfiguracion());

            base.OnModelCreating(modelBuilder);
        }
    }
}
