using API.Backend.Dominio.Entidades;
using API.Backend.Dominio.Servicios.InterfazServicio;
using System;

namespace API.Backend.Dominio.Servicios.ImplementacionServicio
{
    public class ServicioDominioAlumno : IServicioDominioAlumno
    {
        public Alumno CrearAlumno(string aNombreAlumno, string aApellidoAlumno, int aEdad, string aFechaNacimiento)
        {
            return Alumno.CrearAlumno(aNombreAlumno, aApellidoAlumno, aEdad, aFechaNacimiento);
        }

        public Alumno InhabilitarAlumno(Alumno aAlumnoAInhabilitar)
        {
            aAlumnoAInhabilitar.Inhabilitar();
            return aAlumnoAInhabilitar;
        }

        public Alumno ModificarAlumno(Alumno aAlumnoAModificar, string aNombreAlumno, string aApellidoAlumno, int aEdad, string aFechaNacimiento)
        {
            aAlumnoAModificar.ModificarAlumno(
                aNombreAlumno, aApellidoAlumno, aEdad, aFechaNacimiento);
            return aAlumnoAModificar;
        }
    }
}
