using System;
using System.Collections.Generic;

namespace SugerenciaPNetflix.Models;

public partial class UsuarioTipoPelicula
{
    public int IdUsuarioTipoPelicula { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdTipoPelicula { get; set; }

    public virtual TipoPelicula? IdTipoPeliculaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
