using System;

namespace API.Backend.Dominio.Entidades
{
    public class Alumno
    {
        public int CodigoAlumno { get; private set; }
        public string NombreAlumno { get; private set; }
        public string ApellidoAlumno { get; private set; }
        public int Edad { get; private set; }
        public DateTime FechaNacimiento { get; private set; }
        public string IndicadorEstado { get; private set; }
        public static Alumno CrearAlumno(
            string asNombreAlumno,
            string asApellidoAlumno,
            int aiEdad,
            string asFechaNacimiento
            )
        {
            return new Alumno
            {
                NombreAlumno = asNombreAlumno,
                ApellidoAlumno = asApellidoAlumno,
                Edad = aiEdad,
                FechaNacimiento = Convert.ToDateTime(asFechaNacimiento),
                IndicadorEstado = EstadoEntidad.ACTIVO
            };
        }
        public void ModificarAlumno(
            string asNombreAlumno,
            string asApellidoAlumno,
            int aiEdad,
            string asFechaNacimiento
            )
        {
            NombreAlumno = asNombreAlumno;
            ApellidoAlumno = asApellidoAlumno;
            Edad = aiEdad;
            FechaNacimiento = Convert.ToDateTime(asFechaNacimiento);
        }
        public void Inhabilitar()
        {
            IndicadorEstado = EstadoEntidad.INACTIVO;
        }
    }
}
