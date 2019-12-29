using API.Backend.Aplicacion.DTO;
using API.Backend.Aplicacion.Interfaz;
using API.Backend.Dominio.Entidades;
using API.Backend.Dominio.Interfaz;
using System.Collections.Generic;
using System.Linq;

namespace API.Backend.Aplicacion.Implementacion
{
    public class ServicioConsultaAlumno : IServicioConsultaAlumno
    {
        private readonly IRepositorioConsulta _repositorioConsulta;
        private readonly IServicioMapeoEntidadAlumno _servicioMapeo;
        public ServicioConsultaAlumno(IRepositorioConsulta aRepositorioConsulta,
            IServicioMapeoEntidadAlumno aoServicioMapeo)
        {
            _repositorioConsulta = aRepositorioConsulta;
            _servicioMapeo = aoServicioMapeo;
        }
        public DtoAlumno ObtenerAlumno(int aCodigoAlumno)
        {
            var loAlumno = _repositorioConsulta.ObtenerPorCodigo<Alumno>
                (aCodigoAlumno);
            return _servicioMapeo.Mapear(loAlumno);
        }

        public List<DtoAlumno> ObtenerAlumnos()
        {
            var loAlumnos = _repositorioConsulta.ObtenerPorExpresionLimite<Alumno>
                (g => g.IndicadorEstado.Equals(EstadoEntidad.ACTIVO)).ToList();
            return loAlumnos.Select(g => _servicioMapeo.Mapear(g)).ToList();
        }
    }
}
