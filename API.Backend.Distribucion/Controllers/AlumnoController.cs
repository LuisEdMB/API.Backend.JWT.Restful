using API.Backend.Aplicacion.DTO;
using API.Backend.Aplicacion.Interfaz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Backend.Distribucion.Controllers
{
    [Route("api/alumnos")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class AlumnoController : BaseController
    {
        private readonly IServicioConsultaAlumno _goServicioConsultaAlumno;
        private readonly IServicioOperacionAlumno _goServicioOperacionAlumno;
        public AlumnoController(
            IServicioConsultaAlumno aoServicioConsultaAlumno,
            IServicioOperacionAlumno aoServicioOperacionAlumno
            )
        {
            _goServicioConsultaAlumno = aoServicioConsultaAlumno;
            _goServicioOperacionAlumno = aoServicioOperacionAlumno;
        }
        [HttpGet]
        public IActionResult ObtenerTodoListadoDeAlumnos()
        {
            return Ejecutar(() =>
                _goServicioConsultaAlumno.ObtenerAlumnos()
                );
        }
        [HttpGet]
        [Route("{aiCodigoAlumno}")]
        public IActionResult ObtenerAlumno(int aiCodigoAlumno)
        {
            return Ejecutar(() =>
                _goServicioConsultaAlumno.ObtenerAlumno(aiCodigoAlumno)
            );
        }
        [HttpPost]
        public IActionResult GuardarAlumno([FromBody] DtoAlumno aoDtoAlumno)
        {
            return Ejecutar(() =>
                _goServicioOperacionAlumno.GuardarAlumno(aoDtoAlumno)
                );
        }
        [HttpPatch]
        public IActionResult ModificarAlumno([FromBody] DtoAlumno aoDtoAlumno)
        {
            return Ejecutar(() =>
                _goServicioOperacionAlumno.ModificarAlumno(aoDtoAlumno)
                );
        }
        [HttpPatch]
        [Route("{aCodigoAlumno}")]
        public IActionResult InhabilitarAlumno(int aCodigoAlumno)
        {
            return Ejecutar(() =>
                _goServicioOperacionAlumno.InhabilitarAlumno(aCodigoAlumno)
                );
        }
    }
}