using System;
using System.Collections.Generic;

namespace SugerenciaPNetflix.Models;

public partial class TipoPelicula
{
    public int IdTipoPelicula { get; set; }

    public string NombreTipoPelicula { get; set; } = null!;

    public virtual ICollection<PeliculaTipoPelicula> PeliculaTipoPeliculas { get; set; } = new List<PeliculaTipoPelicula>();

    public virtual ICollection<UsuarioTipoPelicula> UsuarioTipoPeliculas { get; set; } = new List<UsuarioTipoPelicula>();
}
