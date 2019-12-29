using API.Backend.Aplicacion.Implementacion;
using API.Backend.Aplicacion.Interfaz;
using API.Backend.Dominio.Interfaz;
using API.Backend.Dominio.Servicios.ImplementacionServicio;
using API.Backend.Dominio.Servicios.InterfazServicio;
using API.Backend.Infraestructura.Configuracion.Contexto;
using API.Backend.Infraestructura.Configuracion.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Backend.Infraestructura.Injector
{
    public class InjectorDependencia
    {
        IServiceCollection services;
        public InjectorDependencia(IServiceCollection aoServices)
        {
            services = aoServices;
        }
        public void ContenedorDependencias(string aCadenaConexion)
        {
            services.AddDbContext<ContextoConsulta>(g => g.UseSqlServer(aCadenaConexion),
                ServiceLifetime.Scoped);

            services.AddDbContext<ContextoOperacion>(g => g.UseSqlServer(aCadenaConexion),
                ServiceLifetime.Scoped);

            services.AddTransient<IRepositorioConsulta, RepositorioConsulta>();
            services.AddTransient<IRepositorioOperacion, RepositorioOperacion>();

            services.AddTransient<IServicioConsultaAlumno, ServicioConsultaAlumno>();
            services.AddTransient<IServicioOperacionAlumno, ServicioOperacionAlumno>();
            services.AddTransient<IServicioMapeoEntidadAlumno, ServicioMapeoEntidadAlumno>();

            services.AddTransient<IServicioDominioAlumno, ServicioDominioAlumno>();
        }
    }
}
