using System;
using System.Collections.Generic;

namespace SugerenciaPNetflix.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public virtual ICollection<UsuarioTipoPelicula> UsuarioTipoPeliculas { get; set; } = new List<UsuarioTipoPelicula>();
}
