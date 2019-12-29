using API.Backend.Aplicacion.DTO;
using API.Backend.Dominio.Entidades;

namespace API.Backend.Aplicacion.Interfaz
{
    public interface IServicioMapeoEntidadAlumno
    {
        DtoAlumno Mapear(Alumno alumno);
    }
}
