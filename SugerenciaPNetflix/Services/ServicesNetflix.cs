using Microsoft.EntityFrameworkCore;
using SugerenciaPNetflix.Models;
using SugerenciaPNetflix.ViewModel;

namespace SugerenciaPNetflix.Services
{
    public class ServicesNetflix : IServicioNetflix
    {
        SugerencaPeliculaContext _context;
        public ServicesNetflix(SugerencaPeliculaContext context)
        {
            _context = context;
        }

        #region TipoPelicula
        public bool registrarTipoPelicula(TipoPeliculaVM tipopel)
        {
            var existe = _context.TipoPeliculas.Where(x => x.NombreTipoPelicula == tipopel.nombre_TipoPelicula).Any();
            bool registrado = false;
            if (!existe)
            {
                using (var context = _context.Database.BeginTransaction())
                {
                    try
                    {
                        TipoPelicula tipo = new TipoPelicula
                        {
                            NombreTipoPelicula = tipopel.nombre_TipoPelicula
                        };
                        _context.TipoPeliculas.Add(tipo);
                        _context.SaveChanges();

                        context.Commit();

                        registrado = true;
                    }
                    catch (Exception)
                    {
                        context.Rollback();
                        registrado = false;
                    }
                }
            }
            return registrado;
        }

        #endregion
    }

}
