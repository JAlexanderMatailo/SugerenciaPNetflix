using Microsoft.AspNetCore.Mvc;
using SugerenciaPNetflix.Services;
using SugerenciaPNetflix.ViewModel;

namespace SugerenciaPNetflix.Controllers
{
    public class ServicesPController : Controller
    {
        private readonly IServicioNetflix _servicioNetflix;

        #region TipoPelicula

            [HttpPost("RegistroTipoPelicula")]
            public IActionResult RegistroTipoPelicula(TipoPeliculaVM tipoPelicula)
            {
                var result = _servicioNetflix.registrarTipoPelicula(tipoPelicula);
                return new JsonResult(result);
            }

            [HttpGet("GetAllTipoPelicula")]
            public IActionResult GetAllTipoPelicula()
            {
                var result = _servicioNetflix.GetAllTipoPelicula();
                return new JsonResult(result);
            }

            [HttpPost("ActualizarTipoPelicula")]
            public IActionResult ActualizarTipoPelicula(TipoPeliculaVM tipoPelicula)
            {
                var resul = _servicioNetflix.actualizarTipoPelicula(tipoPelicula);
                return new JsonResult(resul);
            }
            #endregion
        
    }
}
