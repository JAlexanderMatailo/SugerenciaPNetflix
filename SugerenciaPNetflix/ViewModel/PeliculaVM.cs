namespace SugerenciaPNetflix.ViewModel
{
    public class PeliculaVM
    {
        public int Id_Pelicula { get; set; } // int primary key identity not null,
        public string nombre_pelicula { get; set; } //varchar(50) not null,
        public string duracion_pelicula { get; set; } //varchar(50) not null
        public string imagen { get; set; } //varchar(max) NOT NULL
        public List<TipoPeliculaVM> tipos_pelicula { get; set; }
    }
}
