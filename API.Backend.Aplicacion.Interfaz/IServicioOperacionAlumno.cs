using API.Backend.Aplicacion.DTO;

namespace API.Backend.Aplicacion.Interfaz
{
    public interface IServicioOperacionAlumno
    {
        DtoAlumno GuardarAlumno(DtoAlumno aDtoAlumno);
        DtoAlumno ModificarAlumno(DtoAlumno aDtoAlumno);
        DtoAlumno InhabilitarAlumno(int aCodigoAlumno);
    }
}
