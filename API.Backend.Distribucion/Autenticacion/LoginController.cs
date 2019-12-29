using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Backend.Distribucion.Autenticacion
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private Autenticacion autenticacion;
        public LoginController(IConfiguration configuration)
        {
            autenticacion = new Autenticacion(configuration);
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult IniciarSesion(string asUsuario, string asContrasena)
        {
            return Ok(new { token = autenticacion.GenerarToken() });
        }
    }
}