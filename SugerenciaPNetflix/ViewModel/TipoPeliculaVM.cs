namespace SugerenciaPNetflix.ViewModel
{

    #region TipoPelicula
    public class TipoPeliculaVM
    {
        public int Id_TipoPelicula { get; set; } // int Primary key identity NOT NULL,
        public string nombre_TipoPelicula { get; set; } // varchar(50) not null
    }
    #endregion

    #region Usuario
    public class UsuarioVM
    {
        public int ID_Usuario { get; set; } // int Primary key identity NOT NULL,
        public string Nombre_usuario { get; set; } // varchar(50) not null,
        public DateTime fecha_nacimiento { get; set; } //date not null
        public List<TipoPeliculaVM> tipos { get; set; }
    }
    #endregion

    #region Pelicula
    public class PeliculaVM
    {
        public int Id_Pelicula { get; set; } // int primary key identity not null,
        public string nombre_pelicula { get; set; } //varchar(50) not null,
        public string duracion_pelicula { get; set; } //varchar(50) not null
        public string imagen { get; set; } //varchar(max) NOT NULL
        public List<TipoPeliculaVM> tipos_pelicula { get; set; }
    }
    #endregion

}
