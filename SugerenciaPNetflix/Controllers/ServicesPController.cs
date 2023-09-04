using Microsoft.AspNetCore.Mvc;
using SugerenciaPNetflix.Services;
using SugerenciaPNetflix.ViewModel;

namespace SugerenciaPNetflix.Controllers
{
    public class ServicesPController : Controller
    {
        private readonly IServicioNetflix _servicioNetflix;
        public ServicesPController(IServicioNetflix servicioNetflix)
        {
            _servicioNetflix = servicioNetflix;
        }

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

        #region Usuario
        [HttpPost("RegistroUsuario")]
        public IActionResult RegistroUsuario(UsuarioVM usuario)
        {
            var result = _servicioNetflix.registrarUsuario(usuario);
            return new JsonResult(result);
        }

        [HttpGet("GetAllUsuarios")]
        public IActionResult GetAllUsuarios()
        {
            var result = _servicioNetflix.GetAllUsuarios();
            return new JsonResult(result);
        }

        [HttpPost("ActualizarTipoPelicula")]
        public IActionResult ActualizarUsuarios(UsuarioVM usuario)
        {
            var resul = _servicioNetflix.actualizarUsuarios(usuario);
            return new JsonResult(resul);
        }
        #endregion

        #region Pelicula
        [HttpPost("RegistroPelicula")]
        public IActionResult RegistroPelicula(PeliculaVM pelicula)
        {
            var result = _servicioNetflix.registrarPeliculas(pelicula);
            return new JsonResult(result);
        }

        [HttpGet("GetAllPeliculas")]
        public IActionResult GetAllPeliculas()
        {
            var result = _servicioNetflix.GetAllUsuarios();
            return new JsonResult(result);
        }

        [HttpPost("ActualizarPelicula")]
        public IActionResult ActualizarPelicula(PeliculaVM pelicula)
        {
            var resul = _servicioNetflix.actualizarPelicula(pelicula);
            return new JsonResult(resul);
        }
        #endregion


    }
}
