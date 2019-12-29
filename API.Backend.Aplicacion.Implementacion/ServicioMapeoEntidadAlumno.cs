using API.Backend.Aplicacion.DTO;
using API.Backend.Aplicacion.Interfaz;
using API.Backend.Dominio.Entidades;

namespace API.Backend.Aplicacion.Implementacion
{
    public class ServicioMapeoEntidadAlumno : IServicioMapeoEntidadAlumno
    {
        public DtoAlumno Mapear(Alumno alumno)
        {
            return new DtoAlumno
            {
                CodigoAlumno = alumno.CodigoAlumno,
                NombreAlumno = alumno.NombreAlumno,
                ApellidoAlumno = alumno.ApellidoAlumno,
                Edad = alumno.Edad,
                FechaNacimiento = alumno.FechaNacimiento.ToString("yyyy-MM-dd"),
                IndicadorEstado = alumno.IndicadorEstado
            };
        }
    }
}
