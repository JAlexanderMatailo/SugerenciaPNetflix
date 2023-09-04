using SugerenciaPNetflix.Models;
using SugerenciaPNetflix.ViewModel;

namespace SugerenciaPNetflix.Services
{
    public interface IServicioNetflix
    {
        bool registrarTipoPelicula(TipoPeliculaVM tipopel);
        List<TipoPeliculaVM> GetAllTipoPelicula();
        bool actualizarTipoPelicula(TipoPeliculaVM tipopel);
    }
}
