using API.Backend.Aplicacion.DTO;
using System.Collections.Generic;

namespace API.Backend.Aplicacion.Interfaz
{
    public interface IServicioConsultaAlumno
    {
        List<DtoAlumno> ObtenerAlumnos();
        DtoAlumno ObtenerAlumno(int aCodigoAlumno);
    }
}