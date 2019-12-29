using API.Backend.Aplicacion.DTO;
using API.Backend.Aplicacion.Interfaz;
using API.Backend.Dominio.Entidades;
using API.Backend.Dominio.Interfaz;
using API.Backend.Dominio.Servicios.InterfazServicio;

namespace API.Backend.Aplicacion.Implementacion
{
    public class ServicioOperacionAlumno : IServicioOperacionAlumno
    {
        private readonly IRepositorioOperacion _repositorioOperacion;
        private readonly IServicioDominioAlumno _servicioDominio;
        private readonly IServicioMapeoEntidadAlumno _servicioMapeo;
        public ServicioOperacionAlumno(IRepositorioOperacion aRepositorioOperacion,
            IServicioDominioAlumno aoServicioDominio,
            IServicioMapeoEntidadAlumno aoServicioMapeo)
        {
            _repositorioOperacion = aRepositorioOperacion;
            _servicioDominio = aoServicioDominio;
            _servicioMapeo = aoServicioMapeo;
        }
        public DtoAlumno GuardarAlumno(DtoAlumno aDtoAlumno)
        {
            var loAlumno = _servicioDominio.CrearAlumno(aDtoAlumno.NombreAlumno, aDtoAlumno.ApellidoAlumno,
                aDtoAlumno.Edad, aDtoAlumno.FechaNacimiento);
            _repositorioOperacion.Agregar(loAlumno);
            _repositorioOperacion.GuardarCambios();
            return _servicioMapeo.Mapear(loAlumno);
        }

        public DtoAlumno InhabilitarAlumno(int aCodigoAlumno)
        {
            var loAlumno = _repositorioOperacion.ObtenerPorCodigo<Alumno>
                (aCodigoAlumno);
            loAlumno = _servicioDominio.InhabilitarAlumno(
                loAlumno
                );
            _repositorioOperacion.Modificar(loAlumno);
            _repositorioOperacion.GuardarCambios();
            return _servicioMapeo.Mapear(loAlumno);
        }

        public DtoAlumno ModificarAlumno(DtoAlumno aDtoAlumno)
        {
            var loAlumno = _repositorioOperacion.ObtenerPorCodigo<Alumno>
                (aDtoAlumno.CodigoAlumno);
            loAlumno = _servicioDominio.ModificarAlumno(
                loAlumno, aDtoAlumno.NombreAlumno, aDtoAlumno.ApellidoAlumno,
                aDtoAlumno.Edad, aDtoAlumno.FechaNacimiento
                );
            _repositorioOperacion.Modificar(loAlumno);
            _repositorioOperacion.GuardarCambios();
            return _servicioMapeo.Mapear(loAlumno);
        }
    }
}
