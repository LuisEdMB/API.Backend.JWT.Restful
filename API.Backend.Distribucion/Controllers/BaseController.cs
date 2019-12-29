using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Backend.Distribucion.Controllers
{
    public class BaseController : ControllerBase
    {
        public BaseController()
        {

        }
        public IActionResult Ejecutar<T>(Func<T> action)
        {
            T respuesta;
            try
            {
                respuesta = action();
                return Ok(new { Error = false, Datos = respuesta, Mensaje = "" });
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = true, Datos = "", Mensaje = e.Message });
            }
        }
    }
}