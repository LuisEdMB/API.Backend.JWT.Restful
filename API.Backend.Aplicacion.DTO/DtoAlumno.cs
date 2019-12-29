using System;

namespace API.Backend.Aplicacion.DTO
{
    public class DtoAlumno
    {
        public int CodigoAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public string ApellidoAlumno { get; set; }
        public int Edad { get; set; }
        public string FechaNacimiento { get; set; }
        public string IndicadorEstado { get; set; }
    }
}
