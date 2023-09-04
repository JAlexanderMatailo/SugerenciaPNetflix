using SugerenciaPNetflix.Models;
using SugerenciaPNetflix.ViewModel;

namespace SugerenciaPNetflix.Services
{
    public interface IServicioNetflix
    {
        #region TipoPelicula
        bool registrarTipoPelicula(TipoPeliculaVM tipopel);
        List<TipoPeliculaVM> GetAllTipoPelicula();
        bool actualizarTipoPelicula(TipoPeliculaVM tipopel);
        #endregion

        #region Usuario
        bool registrarUsuario(UsuarioVM usuario);
        List<UsuarioVM> GetAllUsuarios();
        bool actualizarUsuarios(UsuarioVM usuarios);

        #endregion

        #region Pelicula
        bool registrarPeliculas(PeliculaVM peliculaVM);
        List<PeliculaVM> GetAllPeliculas();
        bool actualizarPelicula(PeliculaVM pelicula);
        #endregion


    }
}
