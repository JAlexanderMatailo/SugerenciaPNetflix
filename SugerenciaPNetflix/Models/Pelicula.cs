using System;
using System.Collections.Generic;

namespace SugerenciaPNetflix.Models;

public partial class Pelicula
{
    public int IdPelicula { get; set; }

    public string NombrePelicula { get; set; } = null!;

    public string DuracionPelicula { get; set; } = null!;

    public string? Imagen { get; set; }

    public virtual ICollection<PeliculaTipoPelicula> PeliculaTipoPeliculas { get; set; } = new List<PeliculaTipoPelicula>();
}
