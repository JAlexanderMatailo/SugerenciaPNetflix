using SugerenciaPNetflix.Models;
using SugerenciaPNetflix.ViewModel;

namespace SugerenciaPNetflix.Services
{
    public interface IServicioNetflix
    {
        bool registrarTipoPelicula(TipoPeliculaVM tipopel);
    }
}
