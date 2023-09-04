using System;
using System.Collections.Generic;

namespace SugerenciaPNetflix.Models;

public partial class PeliculaTipoPelicula
{
    public int IdPeliculaTipoPelicula { get; set; }

    public int? IdPelicula { get; set; }

    public int? IdTipoPelicula { get; set; }

    public virtual Pelicula? IdPeliculaNavigation { get; set; }

    public virtual TipoPelicula? IdTipoPeliculaNavigation { get; set; }
}
