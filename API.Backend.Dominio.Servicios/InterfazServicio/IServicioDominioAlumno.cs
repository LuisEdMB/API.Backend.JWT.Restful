using API.Backend.Dominio.Entidades;

namespace API.Backend.Dominio.Servicios.InterfazServicio
{
    public interface IServicioDominioAlumno
    {
        Alumno CrearAlumno(
            string aNombreAlumno,
            string aApellidoAlumno,
            int aEdad,
            string aFechaNacimiento
            );
        Alumno ModificarAlumno(
            Alumno aAlumnoAModificar,
            string aNombreAlumno,
            string aApellidoAlumno,
            int aEdad,
            string aFechaNacimiento
            );
        Alumno InhabilitarAlumno(
            Alumno aAlumnoAInhabilitar
            );
    }
}
